using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System;
using SingBoxLib.Runtime.Api.Clash.Models;

namespace SingBoxLib.Runtime.Api.Clash;

/// <summary>
/// Wrapper client for interacting with sing-box's Clash REST API controller.
/// </summary>
public sealed class ClashApiWrapper : IDisposable
{
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClashApiWrapper"/> class.
    /// </summary>
    /// <param name="apiUrl">The Clash API controller base URL.</param>
    /// <param name="secret">The API secret key (if configured).</param>
    public ClashApiWrapper(string apiUrl, string? secret = null)
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(apiUrl);
        if (secret is not null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {secret}");
        }
    }

    /// <summary>
    /// Disposes the underlying HTTP client.
    /// </summary>
    public void Dispose()
    {
        _client.Dispose();
    }

    /// <summary>
    /// Streams log records from the Clash API.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel stream reading.</param>
    /// <returns>An async enumerable stream of log records.</returns>
    public async IAsyncEnumerable<LogInfo> GetLogs([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await using var stream = await _client.GetStreamAsync("/logs", cancellationToken);
        using var       reader = new StreamReader(stream);
        while (await reader.ReadLineAsync(cancellationToken) is { } update)
        {
            yield return JsonSerializer.Deserialize(update, SingBoxJsonContext.Default.LogInfo)!;
        }
    }

    /// <summary>
    /// Streams connection traffic info from the Clash API.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel stream reading.</param>
    /// <returns>An async enumerable stream of traffic records.</returns>
    public async IAsyncEnumerable<TrafficInfo> GetTraffic([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await using var stream = await _client.GetStreamAsync("/traffic", cancellationToken);
        using var       reader = new StreamReader(stream);
        while (await reader.ReadLineAsync(cancellationToken) is { } update)
        {
            yield return JsonSerializer.Deserialize(update, SingBoxJsonContext.Default.TrafficInfo)!;
        }
    }

    /// <summary>
    /// Retrieves version details of the running Clash API instance.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the async version retrieval.</returns>
    public async Task<VersionInfo> GetVersion(CancellationToken cancellationToken = default)
    {
        return (await _client.GetFromJsonAsync("/version", SingBoxJsonContext.Default.VersionInfo, cancellationToken))!;
    }

    /// <summary>
    /// Retrieves current configuration settings from the Clash API.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the async configuration retrieval.</returns>
    public async Task<ConfigInfo> GetConfig(CancellationToken cancellationToken = default)
    {
        return (await _client.GetFromJsonAsync("/configs", SingBoxJsonContext.Default.ConfigInfo, cancellationToken))!;
    }

    /// <summary>
    /// Updates configuration settings in the Clash API.
    /// </summary>
    /// <param name="config">The config payload to apply.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the async operation.</returns>
    public async Task UpdateConfig(ConfigInfo config, CancellationToken cancellationToken = default)
    {
        await _client.PatchAsJsonAsync("/configs", config, SingBoxJsonContext.Default.ConfigInfo, cancellationToken);
    }

    /// <summary>
    /// Instructs the Clash API to reload the configuration from a path.
    /// </summary>
    /// <param name="configPath">The file path to the new configuration.</param>
    /// <param name="force">Whether to force reload.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the async operation.</returns>
    public async Task ReloadConfig(string configPath, bool force, CancellationToken cancellationToken = default)
    {
        await _client.PutAsJsonAsync($"/configs?force={force}", new ReloadConfigRequest { Path = configPath }, SingBoxJsonContext.Default.ReloadConfigRequest, cancellationToken);
    }

    /// <summary>
    /// Retrieves routing rules from the Clash API.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the rules collection.</returns>
    public async Task<IEnumerable<RuleInfo>> GetRules(CancellationToken cancellationToken = default)
    {
        var response = await _client.GetFromJsonAsync("/rules", SingBoxJsonContext.Default.RulesResponse, cancellationToken);
        return response?.Rules ?? Enumerable.Empty<RuleInfo>();
    }

    /// <summary>
    /// Retrieves proxies list from the Clash API.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the proxies dictionary.</returns>
    public async Task<Dictionary<string, ProxyInfo>> GetProxies(CancellationToken cancellationToken = default)
    {
        var response = await _client.GetFromJsonAsync("/proxies", SingBoxJsonContext.Default.ProxiesResponse, cancellationToken);
        return response?.Proxies ?? new Dictionary<string, ProxyInfo>();
    }

    /// <summary>
    /// Retrieves a proxy detail by its name tag.
    /// </summary>
    /// <param name="name">The proxy name tag.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the proxy details.</returns>
    public async Task<ProxyInfo?> GetProxyByName(string name, CancellationToken cancellationToken = default)
    {
        return await _client.GetFromJsonAsync($"/proxies/{name}", SingBoxJsonContext.Default.ProxyInfo, cancellationToken);
    }

    /// <summary>
    /// Measures the connection delay/latency for a proxy.
    /// </summary>
    /// <param name="name">The proxy name tag.</param>
    /// <param name="timeout">Test timeout in milliseconds.</param>
    /// <param name="url">The target URL to request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the latency details.</returns>
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

    /// <summary>
    /// Switches the selector outbound to target a specific proxy outbound.
    /// </summary>
    /// <param name="name">The proxy name tag.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the async operation.</returns>
    public async Task SelectorSwitchProxy(string name, CancellationToken cancellationToken = default)
    {
        await _client.PutAsync($"/proxies/{name}", null, cancellationToken);
    }

    /// <summary>
    /// Represents the reload configuration request payload.
    /// </summary>
    public class ReloadConfigRequest
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        [JsonPropertyName("path")]
        public string? Path { get; set; }
    }

    /// <summary>
    /// Represents the rules collection response wrapper.
    /// </summary>
    public class RulesResponse
    {
        /// <summary>
        /// Gets or sets the rules list.
        /// </summary>
        [JsonPropertyName("rules")]
        public List<RuleInfo>? Rules { get; set; }
    }

    /// <summary>
    /// Represents the proxies list response wrapper.
    /// </summary>
    public class ProxiesResponse
    {
        /// <summary>
        /// Gets or sets the proxies.
        /// </summary>
        [JsonPropertyName("proxies")]
        public Dictionary<string, ProxyInfo>? Proxies { get; set; }
    }
}
