using SingboxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Converters;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents configuration for a Trojan inbound server.
/// </summary>
public sealed class TrojanInbound : InboundConfig
{

    public TrojanInbound(string? tag = null)
    {
        Type = "trojan";
        Tag = tag ?? "trojan-in";
    }
    /// <summary>
    /// Users allowed to connect to the Trojan server.
    /// </summary>
    [JsonProperty("users")]
    public required List<ProxyUserInbound> Users { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#inbound">TLS</see>.
    /// </summary>
    [JsonProperty("tls")]
    public InboundTlsConfig? Tls { get; set; }

    /// <summary>
    /// Fallback server configuration. Disabled if <see cref="Fallback"/> and <see cref="FallbackForAlpn"/> are empty.
    /// If not empty, can be used as an alternative connection method if primary connection fails or is blocked.
    /// 
    /// Note: There is no evidence that GFW detects and blocks Trojan servers based on HTTP responses,
    /// making this a low-risk fallback strategy with minimal signature exposure.
    /// </summary>
    [JsonProperty("fallback")]
    public TrojanFallback? Fallback { get; set; }

    /// <summary>
    /// Fallback server configurations for specified ALPN protocols.
    /// 
    /// If non-empty, TLS fallback requests with ALPN not in this table will be rejected.
    /// This provides an extra layer of control over connection attempts.
    /// </summary>
    [JsonProperty("fallback_for_alpn")]
    public Dictionary<string, TrojanFallback>? FallbackForAlpn { get; set; }

    /// <summary>
    /// V2Ray Transport configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/v2ray-transport/">V2Ray Transport</see>.
    /// </summary>
    [JsonConverter(typeof(TransportConfigJsonConverter))]
    [JsonProperty("transport")]
    public TransportConfig? Transport { get; set; }

    /// <summary>
    /// Multiplexing configuration for managing multiple streams over a single connection.
    /// </summary>
    [JsonProperty("multiplex")]
    public MultiplexConfig? Multiplex { get; set; }
}

/// <summary>
/// Fallback server configuration when primary connection fails or is blocked.
/// </summary>
public sealed class TrojanFallback
{
    /// <summary>
    /// Server address for fallback connection.
    /// 
    /// If specified, provides an alternative route if the primary connection is interrupted or detected as problematic.
    /// </summary>
    [JsonProperty("server")]
    public string? Server { get; set; }

    /// <summary>
    /// Fallback server port for alternative connection routing.
    /// 
    /// Specifies the port number to use when attempting a fallback connection.
    /// </summary>
    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }
}
