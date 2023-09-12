using SingBoxLib.Configuration;
using SingBoxLib.Configuration.Inbound;
using SingBoxLib.Parsing;
using System.Net;

namespace SingBoxLib.Runtime.Testing;

public class UrlTester
{
    private SingBoxWrapper _wrapper;
    private int _localPort;
    private int _timeout;
    private int _attempts;
    private string _url;

    public UrlTester(SingBoxWrapper singBoxWrapper, int localport, int timeout, int attempts, string? testUrl = null)
    {
        _wrapper = singBoxWrapper;
        _localPort = localport;
        _attempts = attempts;
        _timeout = timeout;
        _url = testUrl ?? "http://cp.cloudflare.com/";
    }

    public async Task<UrlTestResult> TestAsync(ProfileItem profile)
    {
        var config = new SingBoxConfig
        {
            Inbounds = new()
            {
                new SocksInbound
                {
                    Listen = "127.0.0.1",
                    ListenPort = _localPort,
                }
            },
            Log = new()
            {
                Disabled = true,
            },
            Outbounds = new()
            {
                profile.ToOutboundConfig()
            }
        };

        using var proccessCts = new CancellationTokenSource();
        _ = _wrapper.StartAsync(config, proccessCts.Token);

        using var client = new HttpClient(new HttpClientHandler()
        {
            UseProxy = true,
            Proxy = new WebProxy(new Uri($"socks5://127.0.0.1:{_localPort}"))
        });

        UrlTestResult? result = null;

        for (var i = 0; i < _attempts; i++)
        {
            try
            {
                using var timeoutCts = new CancellationTokenSource(_timeout);
                var tmpResult = await UrlTest(client, timeoutCts.Token);
                if (result is null)
                {
                    result = tmpResult;
                    continue;
                }

                if (tmpResult.Delay < result.Delay)
                {
                    result.Success = tmpResult.Success;
                    result.Delay = tmpResult.Delay;
                }
            }
            catch
            {
            }
        }
        proccessCts.Cancel();

        result = result ?? new UrlTestResult();
        result.Profile = profile;

        return result;
    }

    private async Task<UrlTestResult> UrlTest(HttpClient client, CancellationToken cancellationToken)
    {
        var startTime = DateTime.Now;

        var result = await client.GetAsync(_url, cancellationToken);
        return new()
        {
            Success = result.IsSuccessStatusCode,
            Delay = (int)(DateTime.Now - startTime).TotalMilliseconds
        };
    }
}