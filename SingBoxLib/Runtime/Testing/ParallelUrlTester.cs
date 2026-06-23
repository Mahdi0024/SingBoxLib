namespace SingBoxLib.Runtime.Testing;

/// <summary>
/// Performs parallel latency and health testing on a collection of proxy profiles.
/// </summary>
public sealed class ParallelUrlTester : IDisposable
{
    private readonly int             _maxConcurrency;
    private readonly int             _localPort;
    private readonly int             _timeout;
    private readonly string          _testUrl;
    private readonly ClashApiWrapper _clashApi;
    private readonly SingBoxWrapper  _singBoxWrapper;
    private readonly int             _testChunkCount;
    private          int             _activeConcurrency;
    private          bool            _running;

    /// <summary>
    /// Gets the number of currently active concurrent testing tasks.
    /// </summary>
    public int ActiveConcurrency => _activeConcurrency;


    /// <summary>
    /// Initializes a new instance of the <see cref="ParallelUrlTester"/> class.
    /// </summary>
    /// <param name="singBoxWrapper">The wrapper instance for running sing-box.</param>
    /// <param name="localPort">The local port for Clash API controller.</param>
    /// <param name="maxConcurrency">The maximum number of concurrent test tasks.</param>
    /// <param name="timeout">The request timeout in milliseconds.</param>
    /// <param name="testChunkCount">The number of proxies tested in each batch.</param>
    /// <param name="testUrl">The URL to test latency against. Defaults to Cloudflare CP.</param>
    public ParallelUrlTester(SingBoxWrapper singBoxWrapper, int localPort, int maxConcurrency, int timeout, int testChunkCount, string? testUrl = null)
    {
        _singBoxWrapper = singBoxWrapper;
        _maxConcurrency = maxConcurrency;
        _localPort      = localPort;
        _timeout        = timeout;
        _testUrl        = testUrl ?? "http://cp.cloudflare.com/";
        _clashApi       = new ClashApiWrapper($"http://127.0.0.1:{_localPort}");
        _testChunkCount = testChunkCount;
    }

    /// <summary>
    /// Performs parallel latency testing on the provided list of profiles and reports progress.
    /// </summary>
    /// <param name="profiles">The list of profiles to test.</param>
    /// <param name="progressReporter">The progress reporter for results.</param>
    /// <param name="cancellationToken">Cancellation token to stop the test.</param>
    public async Task ParallelTestAsync(IEnumerable<ProfileItem> profiles, IProgress<UrlTestResult> progressReporter, CancellationToken cancellationToken)
    {
        if (_running)
        {
            throw new InvalidOperationException("Url tester is already running!");
        }

        _running = true;

        var testChunks = profiles.Chunk(_testChunkCount);

        foreach (var chunk in testChunks)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var outbounds     = new List<OutboundConfig>();
            var profileTagMap = new Dictionary<ProfileItem, int>();

            foreach (var (index, profile) in chunk.Index())
            {
                try
                {
                    var outbound = profile.ToOutboundConfig().WithTag(index.ToString());
                    outbounds.Add(outbound);
                    profileTagMap.Add(profile, index);
                }
                catch
                {
                    progressReporter.Report(new UrlTestResult
                    {
                        Profile = profile,
                        Success = false
                    });
                }
            }

            var config = new SingBoxConfig
            {
                Outbounds = outbounds,
                Log = new()
                {
                    Level = LogLevels.Error
                },
                Experimental = new()
                {
                    ClashApi = new()
                    {
                        ExternalController = $"127.0.0.1:{_localPort}",
                    }
                }
            };

            using var processCancellationToken               = new CancellationTokenSource();
            using var processAndInputCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(processCancellationToken.Token, cancellationToken);

            var singBoxTask = _singBoxWrapper.StartAsync(config, processAndInputCancellationTokenSource.Token);
            try
            {
                await Parallel.ForEachAsync(chunk, new ParallelOptions { MaxDegreeOfParallelism = _maxConcurrency }, async (profile, token) =>
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    Interlocked.Increment(ref _activeConcurrency);

                    using var requestTimeoutToken       = new CancellationTokenSource(_timeout);
                    using var combinedCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(processAndInputCancellationTokenSource.Token, requestTimeoutToken.Token);

                    int  delay   = 0;
                    bool success = false;

                    try
                    {
                        var delayInfo = await _clashApi.GetProxyDelay(profileTagMap[profile].ToString(), _timeout, _testUrl, combinedCancellationToken.Token);
                        delay   = delayInfo.Delay;
                        success = delayInfo.Success;
                    }
                    catch
                    {
                        success = false;
                    }
                    finally
                    {
                        var result = new UrlTestResult
                        {
                            Profile = profile,
                            Delay   = delay,
                            Success = success
                        };
                        progressReporter.Report(result);
                    }

                    Interlocked.Decrement(ref _activeConcurrency);
                });
            }
            finally
            {
                await processCancellationToken.CancelAsync();
                try
                {
                    await singBoxTask;
                }
                catch
                {
                    // Suppress expected task cancellation exception on exit
                }
            }
        }

        _running = false;
    }

    /// <summary>
    /// Disposes the underlying API client.
    /// </summary>
    public void Dispose()
    {
        _clashApi.Dispose();
    }
}