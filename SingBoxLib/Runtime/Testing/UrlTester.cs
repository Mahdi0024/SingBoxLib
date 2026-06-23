namespace SingBoxLib.Runtime.Testing;

/// <summary>
/// Tester for measuring latency of a single proxy profile.
/// </summary>
public class UrlTester
{
    private readonly SingBoxWrapper _wrapper;
    private readonly int            _localPort;
    private readonly int            _timeout;
    private readonly int            _attempts;
    private readonly string         _url;

    /// <summary>
    /// Initializes a new instance of the <see cref="UrlTester"/> class.
    /// </summary>
    /// <param name="singBoxWrapper">The wrapper instance for running sing-box.</param>
    /// <param name="localport">The local port for the SOCKS proxy inbound.</param>
    /// <param name="timeout">The request timeout in milliseconds.</param>
    /// <param name="attempts">The number of latency test attempts.</param>
    /// <param name="testUrl">The URL to test latency against. Defaults to Cloudflare CP.</param>
    public UrlTester(SingBoxWrapper singBoxWrapper, int localport, int timeout, int attempts, string? testUrl = null)
    {
        _wrapper   = singBoxWrapper;
        _localPort = localport;
        _attempts  = attempts;
        _timeout   = timeout;
        _url       = testUrl ?? "http://cp.cloudflare.com/";
    }

    /// <summary>
    /// Tests the latency of the specified proxy profile.
    /// </summary>
    /// <param name="profile">The proxy profile to test.</param>
    /// <returns>A task representing the async test operation, returning the test result.</returns>
    public async Task<UrlTestResult> TestAsync(ProfileItem profile)
    {
        OutboundConfig? outbound;
        try
        {
            outbound = profile.ToOutboundConfig();
        }
        catch
        {
            return new UrlTestResult { Profile = profile, Success = false, Delay = 0 };
        }

        var config = new SingBoxConfig
        {
            Inbounds = new()
            {
                new SocksInbound
                {
                    Listen     = "127.0.0.1",
                    ListenPort = _localPort,
                }
            },
            Log = new()
            {
                Disabled = true,
            },
            Outbounds = new()
            {
                outbound
            }
        };

        using var processCts = new CancellationTokenSource();
        _ = _wrapper.StartAsync(config, processCts.Token);

        using var client = new HttpClient(new HttpClientHandler()
        {
            UseProxy = true,
            Proxy    = new WebProxy(new Uri($"socks5://127.0.0.1:{_localPort}"))
        });

        UrlTestResult? bestResult = null;

        for (var i = 0; i < _attempts; i++)
        {
            try
            {
                using var timeoutCts = new CancellationTokenSource(_timeout);
                var       tmpResult  = await UrlTest(client, profile, timeoutCts.Token);
                if (bestResult is null || tmpResult.Delay < bestResult.Value.Delay)
                {
                    bestResult = tmpResult;
                }
            }
            catch
            {
                // Ignore failed attempts
            }
        }

        await processCts.CancelAsync();

        return bestResult ?? new UrlTestResult { Profile = profile, Success = false, Delay = 0 };
    }

    private async Task<UrlTestResult> UrlTest(HttpClient client, ProfileItem profile, CancellationToken cancellationToken)
    {
        var startTime = DateTime.Now;

        var result = await client.GetAsync(_url, cancellationToken);
        return new UrlTestResult
        {
            Profile = profile,
            Success = result.IsSuccessStatusCode,
            Delay   = (int)(DateTime.Now - startTime).TotalMilliseconds
        };
    }
}