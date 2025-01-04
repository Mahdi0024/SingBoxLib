using SingboxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Inbound.Abstract;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents configuration for a Hysteria inbound server.
/// </summary>
public sealed class HysteriaInbound : InboundConfig
{
    public HysteriaInbound(string? tag = null)
    {
        Type = "hysteria";
        Tag = tag ?? "hysteria-in";
    }

    /// <summary>
    /// Upstream bandwidth limit.
    /// If not specified, default behavior will be used. 
    /// Supports units:
    ///     bps (bits per second)
    ///     Bps(bytes per second)
    ///     Kbps(kilobits per second)
    ///     KBps(kilobytes per second)
    ///     Mbps(megabits per second)
    ///     MBps(megabytes per second)
    ///     Gbps(gigabits per second)
    ///     GBps(gigabytes per second)
    ///     Tbps(terabits per second)
    ///     TBps(terabytes per second)
    /// </summary>
    [JsonProperty("up")]
    public string? Up { get; set; }

    /// <summary>
    /// Upstream bandwidth limit in megabits per second (Mbps).
    /// If not specified, default behavior will be used. 
    /// </summary>
    [JsonProperty("up_mbps")]
    public int? UpMbps { get; set; }

    /// <summary>
    /// Downstream bandwidth limit.
    /// If not specified, default behavior will be used. 
    /// Supports units:
    ///     bps (bits per second)
    ///     Bps (bytes per second)
    ///     Kbps(kilobits per second)
    ///     KBps(kilobytes per second)
    ///     Mbps(megabits per second)
    ///     MBps(megabytes per second)
    ///     Gbps(gigabits per second)
    ///     GBps(gigabytes per second)
    ///     Tbps(terabits per second)
    ///     TBps(terabytes per second)
    /// </summary>
    [JsonProperty("down")]
    public string? Down { get; set; }

    /// <summary>
    /// Downstream bandwidth limit in megabits per second (Mbps).
    /// If not specified, default behavior will be used. 
    /// </summary>
    [JsonProperty("down_mbps")]
    public int? DownMbps { get; set; }

    /// <summary>
    /// Optional obfuscation method for the connection.
    /// Helps bypass network restrictions or increase anonymity.
    /// </summary>
    [JsonProperty("obfs")]
    public string? Obfs { get; set; }

    /// <summary>
    /// List of users for authentication.
    /// </summary>
    [JsonProperty("users")]
    public List<HysteriaUser>? Users { get; set; }

    /// <summary>
    /// QUIC stream-level receive window connection setting.
    /// Controls the maximum amount of data that can be received at once.
    /// If not specified, default of 15 MB/s (15728640) will be used.
    /// </summary>
    [JsonProperty("recv_window_conn")]
    public int? RecvWindowConn { get; set; }

    /// <summary>
    /// QUIC connection-level receive window setting.
    /// Controls the total data that can be received across all streams.
    /// If not specified, default of 64 MB/s (67108864) will be used.
    /// </summary>
    [JsonProperty("recv_window_client")]
    public int? RecvWindowClient { get; set; }

    /// <summary>
    /// Maximum number of concurrent bidirectional QUIC streams allowed per peer.
    /// If not specified, default of 1024 will be used.
    /// </summary>
    [JsonProperty("max_conn_client")]
    public int? MaxConnClient { get; set; }

    /// <summary>
    /// Disables Path MTU Discovery for more consistent packet sizes.
    /// Force enabled on non-Linux and Windows systems.
    /// </summary>
    [JsonProperty("disable_mtu_discovery")]
    public bool? DisableMtuDiscovery { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#inbound">TLS</see>.
    /// </summary>
    [JsonProperty("tls")]
    public InboundTlsConfig? Tls { get; set; }
}

/// <summary>
/// Represents a user configuration for Hysteria.
/// </summary>
public class HysteriaUser
{
    /// <summary>
    /// User name or identifier.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Base64 encoded authentication password.
    /// Used for establishing secure connection.
    /// </summary>
    [JsonProperty("auth")]
    public string? AuthBase64 { get; set; }

    /// <summary>
    /// Plain text authentication password.
    /// Can be used alongside base64 encoded version.
    /// </summary>
    [JsonProperty("auth_str")]
    public string? AuthStr { get; set; }
}
