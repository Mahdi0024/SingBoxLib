using SingboxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents a mixed inbound configuration for SOCKS and HTTP proxy.
/// </summary>
public sealed class MixedInbound : InboundConfig
{
    public MixedInbound(string? tag = null)
    {
        Type = "mixed";
        Tag = tag ?? "mixed-in";
    }
    /// <summary>
    /// List of users allowed to connect via this proxy. 
    /// Can be used for SOCKS or HTTP authentication when required.
    /// When empty, no authentication is needed.
    /// </summary>
    [JsonProperty("users")]
    public List<ProxyUser>? Users { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#inbound">TLS</see>.
    /// </summary>
    [JsonProperty("tls")]
    public InboundTlsConfig? Tls { get; set; }

    /// <summary>
    /// Indicates whether system proxy settings should be used on supported platforms.
    /// Only applicable on Linux, Android, Windows, and macOS.
    /// On other platforms or without proper privileges, consider using tun.platform.http_proxy instead.
    /// </summary>
    [JsonProperty("set_system_proxy")]
    public bool? SetSystemProxy { get; set; }
}
