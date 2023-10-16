using SingBoxLib.Runtime.Api.Clash.Models;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace SingboxLib.Runtime.Api.Clash;

public class ClashApiWrapper : IDisposable
{
    private HttpClient _client;
    private string _apiUrl;

    public ClashApiWrapper(string apiUrl, string? secret = null)
    {
        _apiUrl = apiUrl;
        _client = new HttpClient();
        _client.BaseAddress = new Uri(apiUrl);
        if (secret is not null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {secret}");
        }
    }

    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }

    public async IAsyncEnumerable<LogInfo> GetLogs([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using var stream = await _client.GetStreamAsync("/logs", cancellationToken);
        using (var reader = new StreamReader(stream))
        {
            while (!reader.EndOfStream)
            {
                var update = await reader.ReadLineAsync(cancellationToken);
                yield return JsonConvert.DeserializeObject<LogInfo>(update!)!;
            }
        }
    }

    public async IAsyncEnumerable<TrafficInfo> GetTraffic([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using var stream = await _client.GetStreamAsync("/traffic", cancellationToken);
        using (var reader = new StreamReader(stream))
        {
            while (!reader.EndOfStream)
            {
                var update = await reader.ReadLineAsync(cancellationToken);
                yield return JsonConvert.DeserializeObject<TrafficInfo>(update!)!;
            }
        }
    }

    public async Task<VersionInfo> GetVersion()
    {
        return (await _client.GetFromJsonAsync<VersionInfo>("/version"))!;
    }

    public async Task<ConfigInfo> GetConfig()
    {
        return (await _client.GetFromJsonAsync<ConfigInfo>("/configs"))!;
    }

    public async Task UpdateConfig(ConfigInfo config)
    {
        await _client.PatchAsJsonAsync("/configs", config);
    }

    public async Task ReloadConfig(string configPath, bool force)
    {
        var response = await _client.PutAsJsonAsync($"/configs?force={force}", new { Path = configPath });
    }

    public async Task<IEnumerable<RuleInfo>> GetRules()
    {
        var response = await _client.GetFromJsonAsync<Dictionary<string, IEnumerable<RuleInfo>>>("/rules");
        return response!["rules"];
    }

    public async Task<Dictionary<string, ProxyInfo>> GetProxies()
    {
        var response = await _client.GetFromJsonAsync<Dictionary<string, Dictionary<string, ProxyInfo>>>("/proxies");
        return response!["proxies"];
    }

    public async Task<ProxyInfo?> GetProxyByName(string name)
    {
        return await _client.GetFromJsonAsync<ProxyInfo>($"/proxies/{name}");
    }

    public async Task<ProxyDelayInfo> GetProxyDelay(string name, int timeout, string url = null)
    {
        var response = await _client.GetAsync($"/proxies/{name}/delay?timeout={timeout}&url={url}");
        if (response.StatusCode is not HttpStatusCode.OK)
        {
            return new ProxyDelayInfo();
        }

        var delayInfo = JsonConvert.DeserializeObject<ProxyDelayInfo>(await response.Content.ReadAsStringAsync());
        delayInfo!.Success = true;
        return delayInfo;
    }

    public async Task SelectorSwitchProxy(string name)
    {
        await _client.PutAsync($"/proxies/{name}", null);
    }
}