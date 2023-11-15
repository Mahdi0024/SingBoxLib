using SingboxLib.Runtime.Api.Clash;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration;
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
    private int _activeThreads;
    public int ActiveThreads { get => _activeThreads; }

    private bool _running;

    public ParallelUrlTester(SingBoxWrapper singBoxWrapper, int localPort, int maxThreads, int timeout, string? testUrl = null)
    {
        _singBoxWrapper = singBoxWrapper;
        _maxThreads = maxThreads;
        _localPort = localPort;
        _timeout = timeout;
        _testUrl = testUrl ?? "http://cp.cloudflare.com/";
        _clashApi = new ClashApiWrapper($"http://127.0.0.1:{_localPort}");
    }

    public async Task ParallelTestAsync(IEnumerable<ProfileItem> profiles, IProgress<UrlTestResult> progressReporter, CancellationToken cancellationToken)
    {
        if (_running)
        {
            throw new InvalidOperationException($"Url tester is already running!");
        }
        _running = true;


        var outbounds = new List<OutboundConfig>();
        foreach (var profile in profiles)
        {
            var outbound = profile.ToOutboundConfig();
            outbound.Tag = profile.Name;
            outbounds.Add(outbound);
        }


        var config = new SingBoxConfig
        {
            Outbounds = outbounds,
            Log = new()
            {
                Disabled = true,
            },
            Experimental = new()
            {
                ClashApi = new()
                {
                    ExternalController = $"127.0.0.1:{_localPort}",
                }
            }
        };

        using var cts = new CancellationTokenSource();
        _ = _singBoxWrapper.StartAsync(config, cts.Token);
        try
        {
            await Parallel.ForEachAsync(profiles, new ParallelOptions { MaxDegreeOfParallelism = _maxThreads }, async (profile, token) =>
            {
                Interlocked.Increment(ref _activeThreads);

                using var requestTimeoutToken = new CancellationTokenSource(_timeout);
                using var combinedCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, requestTimeoutToken.Token);

                var result = new UrlTestResult();
                result.Profile = profile;

                try
                {
                    var delayInfo = await _clashApi.GetProxyDelay(profile.Name!, _timeout, _testUrl, combinedCancellationToken.Token);
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
            cts.Cancel();
            _activeThreads = 0;
            _running = false;
        }

    }

    public void Dispose()
    {
        _clashApi.Dispose();
        GC.SuppressFinalize(this);
    }
}