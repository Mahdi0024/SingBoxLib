namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents a mixed inbound configuration for SOCKS and HTTP proxy.
/// </summary>
public sealed class MixedInbound : InboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MixedInbound"/> class.
    /// </summary>
    /// <param name="tag">The optional inbound tag.</param>
    public MixedInbound(string? tag = null)
    {
        Type = "mixed";
        Tag = tag;
    }
    /// <summary>
    /// List of users allowed to connect via this proxy. 
    /// Can be used for SOCKS or HTTP authentication when required.
    /// When empty, no authentication is needed.
    /// </summary>
    [JsonPropertyName("users")]
    public List<ProxyUser>? Users { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#inbound">TLS</see>.
    /// </summary>
    [JsonPropertyName("tls")]
    public InboundTlsConfig? Tls { get; set; }

    /// <summary>
    /// Indicates whether system proxy settings should be used on supported platforms.
    /// Only applicable on Linux, Android, Windows, and macOS.
    /// On other platforms or without proper privileges, consider using tun.platform.http_proxy instead.
    /// </summary>
    [JsonPropertyName("set_system_proxy")]
    public bool? SetSystemProxy { get; set; }
}
