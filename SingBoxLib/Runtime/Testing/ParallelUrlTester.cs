using SingboxLib.Runtime.Api.Clash;
using SingBoxLib.Configuration;
using SingBoxLib.Configuration.Log;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Parsing;

namespace SingBoxLib.Runtime.Testing;

public class ParallelUrlTester : IDisposable
{
    private readonly int _maxThreads;
    private readonly int _localPort;
    private readonly int _timeout;
    private readonly string _testUrl;
    private readonly ClashApiWrapper _clashApi;
    private readonly SingBoxWrapper _singBoxWrapper;
    private readonly int _testChunkCount;
    private int _activeThreads;
    public int ActiveThreads { get => _activeThreads; }

    private bool _running;

    public ParallelUrlTester(SingBoxWrapper singBoxWrapper, int localPort, int maxThreads, int timeout, int testCunkCount, string? testUrl = null)
    {
        _singBoxWrapper = singBoxWrapper;
        _maxThreads = maxThreads;
        _localPort = localPort;
        _timeout = timeout;
        _testUrl = testUrl ?? "http://cp.cloudflare.com/";
        _clashApi = new ClashApiWrapper($"http://127.0.0.1:{_localPort}");
        _testChunkCount = testCunkCount;
    }

    public async Task ParallelTestAsync(IEnumerable<ProfileItem> profiles, IProgress<UrlTestResult> progressReporter, CancellationToken cancellationToken)
    {
        if (_running)
        {
            throw new InvalidOperationException($"Url tester is already running!");
        }
        _running = true;

        var testCunks = profiles.Chunk(_testChunkCount);

        foreach (var chunk in testCunks)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var outbounds = new List<OutboundConfig>();

            var profileTagMap = new Dictionary<ProfileItem, int>();

            var count = 0;
            foreach (var profile in chunk)
            {
                try
                {
                    var outbound = profile.ToOutboundConfig();
                    outbound.Tag = count.ToString();
                    outbounds.Add(outbound);
                    profileTagMap.Add(profile, count);
                    count++;
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

            using var proccessCancellationToken = new CancellationTokenSource();
            using var proccessAndInputCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(proccessCancellationToken.Token, cancellationToken);

            try
            {
                var singBoxTask = _singBoxWrapper.StartAsync(config, proccessAndInputCancellationToken.Token);
                await Parallel.ForEachAsync(profiles, new ParallelOptions { MaxDegreeOfParallelism = _maxThreads }, async (profile, token) =>
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    Interlocked.Increment(ref _activeThreads);

                    using var requestTimeoutToken = new CancellationTokenSource(_timeout);
                    using var combinedCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(proccessAndInputCancellationToken.Token, requestTimeoutToken.Token);

                    var result = new UrlTestResult();
                    result.Profile = profile;

                    try
                    {
                        var delayInfo = await _clashApi.GetProxyDelay(profileTagMap[profile].ToString(), _timeout, _testUrl, combinedCancellationToken.Token);
                        result.Delay = delayInfo.Delay;
                        result.Success = delayInfo.Success;
                    }
                    catch
                    {
                        result.Success = false;
                    }
                    finally
                    {
                        progressReporter.Report(result);
                    }
                    Interlocked.Decrement(ref _activeThreads);
                });
            }
            finally
            {
                proccessCancellationToken.Cancel();
            }
        }
        _running = false;
    }

    public void Dispose()
    {
        _clashApi.Dispose();
        GC.SuppressFinalize(this);
    }
}