using SingboxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents a HTTP inbound configuration.
/// </summary>
public sealed class HttpInbound : InboundConfig
{
    public HttpInbound(string? tag = null)
    {
        Type = "http";
        Tag = tag ?? "http-in";
    }

    /// <summary>
    /// List of HTTP users associated with this inbound server. If empty, no authentication is required.
    /// </summary>
    [JsonProperty("users")]
    public List<ProxyUser>? Users { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#inbound">TLS</see>.
    /// </summary>
    [JsonProperty("tls")]
    public InboundTlsConfig? Tls { get; set; }

    /// <summary>
    /// Enables system proxy configuration on supported platforms when using this inbound server.
    /// 
    /// - Linux
    /// - Android
    /// - macOS
    /// - Windows
    /// 
    /// Automatically sets the platform's HTTP proxy when the server starts and cleans up after stopping.
    /// On non-supported platforms, use <c>tun.platform.http_proxy</c> instead.
    /// </summary>
    [JsonProperty("set_system_proxy")]
    public bool? SetSystemProxy { get; set; }
}
