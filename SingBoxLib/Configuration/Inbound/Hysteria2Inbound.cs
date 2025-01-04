using SingboxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents configuration for a Hysteria 2 inbound server.
/// </summary>
public sealed class Hysteria2Inbound : InboundConfig
{
    public Hysteria2Inbound(string? tag = null)
    {
        Type = "hysteria2";
        Tag = tag ?? "hysteria2-in";
    }

    /// <summary>
    /// Maximum upload bandwidth in Mbps. When empty, no upper limit is set.
    /// 
    /// Conflict with <see cref="IgnoreClientBandwidth"/>.
    /// </summary>
    [JsonProperty("up_mbps")]
    public int UpMbps { get; set; }

    /// <summary>
    /// Maximum download bandwidth in Mbps. When empty, no upper limit is set.
    /// 
    /// Conflict with <see cref="IgnoreClientBandwidth"/>.
    /// </summary>
    [JsonProperty("down_mbps")]
    public int DownMbps { get; set; }

    /// <summary>
    /// QUIC traffic obfuscation configuration for the connection.
    /// When empty, obfuscation is disabled.
    /// 
    /// Requires 'salamander' to be enabled in order to use QUIC obfuscation.
    /// </summary>
    [JsonProperty("obfs")]
    public Hysteria2Obfs? Obfs { get; set; }

    /// <summary>
    /// List of configured users for this connection.
    /// </summary>
    [JsonProperty("users")]
    public List<ProxyUserInbound>? Users { get; set; }

    /// <summary>
    /// Enables the use of BBR flow control algorithm instead of Hysteria's CC.
    /// Conflicts with explicit bandwidth limits.
    /// 
    /// When enabled, clients will be instructed to use the Bandwidth Benchmarking
    /// (BBR) algorithm for flow control.
    /// </summary>
    [JsonProperty("ignore_client_bandwidth")]
    public bool IgnoreClientBandwidth { get; set; }

    /// <summary>
    /// HTTP3 server behavior configuration when authentication fails.
    /// 
    /// When not configured, returns a 404 page.
    /// 
    /// Supports three modes: file, http/https, and string responses.
    /// </summary>
    [JsonProperty("masquerade")]
    public Hysteria2Masquerade? Masquerade { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#inbound">TLS</see>.
    /// </summary>
    [JsonProperty("tls")]
    public InboundTlsConfig? Tls { get; set; }

    /// <summary>
    /// Enables debug information logging for Hysteria Brutal CC algorithm.
    /// </summary>
    [JsonProperty("brutal_debug")]
    public bool BrutalDebug { get; set; }
}



/// <summary>
/// Represents configuration for masquerading HTTP server behavior.
/// </summary>
public class Hysteria2Masquerade
{
    /// <summary>
    /// The network scheme to use (e.g., "file", "http", "https").
    /// </summary>
    public string? Scheme { get; set; }

    /// <summary>
    /// The type of masquerade server configuration.
    /// Supported types: "file" or "proxy".
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Directory path for file server mode.
    /// Only used when Scheme is "file".
    /// </summary>
    public string? Directory { get; set; }

    /// <summary>
    /// Target URL for proxy mode.
    /// Only used when Type is "proxy".
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Host to rewrite in proxy configuration.
    /// Only used when Type is "proxy".
    /// </summary>
    public string? RewriteHost { get; set; }

    /// <summary>
    /// Fixed HTTP status code for masquerade responses.
    /// </summary>
    public int? StatusCode { get; set; }

    /// <summary>
    /// Additional headers to include in masquerade responses.
    /// </summary>
    public Dictionary<string, string>? Headers { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Fixed response content for masquerade scenarios.
    /// </summary>
    public string? Content { get; set; }
}