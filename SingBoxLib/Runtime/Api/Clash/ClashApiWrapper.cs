using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using SingBoxLib.Configuration;
using SingBoxLib.Runtime.Api.Clash.Models;

namespace SingBoxLib.Runtime.Api.Clash;

public sealed class ClashApiWrapper : IDisposable
{
    private readonly HttpClient _client;

    public ClashApiWrapper(string apiUrl, string? secret = null)
    {
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
    }

    public async IAsyncEnumerable<LogInfo> GetLogs([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await using var stream = await _client.GetStreamAsync("/logs", cancellationToken);
        using var       reader = new StreamReader(stream);
        while (!reader.EndOfStream)
        {
            var update = await reader.ReadLineAsync(cancellationToken);
            yield return JsonSerializer.Deserialize(update!, SingBoxJsonContext.Default.LogInfo)!;
        }
    }

    public async IAsyncEnumerable<TrafficInfo> GetTraffic([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await using var stream = await _client.GetStreamAsync("/traffic", cancellationToken);
        using var       reader = new StreamReader(stream);
        while (!reader.EndOfStream)
        {
            var update = await reader.ReadLineAsync(cancellationToken);
            yield return JsonSerializer.Deserialize(update!, SingBoxJsonContext.Default.TrafficInfo)!;
        }
    }

    public async Task<VersionInfo> GetVersion(CancellationToken cancellationToken = default)
    {
        return (await _client.GetFromJsonAsync("/version", SingBoxJsonContext.Default.VersionInfo, cancellationToken))!;
    }

    public async Task<ConfigInfo> GetConfig(CancellationToken cancellationToken = default)
    {
        return (await _client.GetFromJsonAsync("/configs", SingBoxJsonContext.Default.ConfigInfo, cancellationToken))!;
    }

    public async Task UpdateConfig(ConfigInfo config, CancellationToken cancellationToken = default)
    {
        await _client.PatchAsJsonAsync("/configs", config, SingBoxJsonContext.Default.ConfigInfo, cancellationToken);
    }

    public async Task ReloadConfig(string configPath, bool force, CancellationToken cancellationToken = default)
    {
        await _client.PutAsJsonAsync($"/configs?force={force}", new ReloadConfigRequest { Path = configPath }, SingBoxJsonContext.Default.ReloadConfigRequest, cancellationToken);
    }

    public async Task<IEnumerable<RuleInfo>> GetRules(CancellationToken cancellationToken = default)
    {
        var response = await _client.GetFromJsonAsync("/rules", SingBoxJsonContext.Default.RulesResponse, cancellationToken);
        return response?.Rules ?? Enumerable.Empty<RuleInfo>();
    }

    public async Task<Dictionary<string, ProxyInfo>> GetProxies(CancellationToken cancellationToken = default)
    {
        var response = await _client.GetFromJsonAsync("/proxies", SingBoxJsonContext.Default.ProxiesResponse, cancellationToken);
        return response?.Proxies ?? new Dictionary<string, ProxyInfo>();
    }

    public async Task<ProxyInfo?> GetProxyByName(string name, CancellationToken cancellationToken = default)
    {
        return await _client.GetFromJsonAsync($"/proxies/{name}", SingBoxJsonContext.Default.ProxyInfo, cancellationToken);
    }

    public async Task<ProxyDelayInfo> GetProxyDelay(string name, int timeout, string? url = null, CancellationToken cancellationToken = default)
    {
        var response = await _client.GetAsync($"/proxies/{name}/delay?timeout={timeout}&url={url}", cancellationToken);
        if (response.StatusCode is not HttpStatusCode.OK)
        {
            return new ProxyDelayInfo();
        }

        var delayInfo = JsonSerializer.Deserialize(await response.Content.ReadAsStringAsync(cancellationToken), SingBoxJsonContext.Default.ProxyDelayInfo);
        delayInfo!.Success = true;
        return delayInfo;
    }

    public async Task SelectorSwitchProxy(string name, CancellationToken cancellationToken = default)
    {
        await _client.PutAsync($"/proxies/{name}", null, cancellationToken);
    }

    public class ReloadConfigRequest
    {
        [JsonPropertyName("path")]
        public string? Path { get; set; }
    }

    public class RulesResponse
    {
        [JsonPropertyName("rules")]
        public List<RuleInfo>? Rules { get; set; }
    }

    public class ProxiesResponse
    {
        [JsonPropertyName("proxies")]
        public Dictionary<string, ProxyInfo>? Proxies { get; set; }
    }
}
