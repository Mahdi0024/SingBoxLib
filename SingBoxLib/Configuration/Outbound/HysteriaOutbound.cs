namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a Hysteria outbound.
/// </summary>
public sealed class HysteriaOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HysteriaOutbound"/> class.
    /// </summary>
    /// <param name="tag">The optional outbound tag.</param>
    public HysteriaOutbound(string? tag = null)
    {
        Type = "hysteria";
        Tag = tag ?? "hysteria-out";
    }

    /// <summary>
    /// The server address.
    /// </summary>
    [JsonPropertyName("server")]
    public required string Server { get; set; }

    /// <summary>
    /// The server port.
    /// </summary>
    [JsonPropertyName("server_port")]
    public required int ServerPort { get; set; }

    /// <summary>
    /// Format: [Integer] [Unit] e.g. 100 Mbps, 640 KBps, 2 Gbps.
    /// Supported units (case sensitive, b = bits, B = bytes, 8b=1B):
    /// bps (bits per second)
    /// Bps(bytes per second)
    /// Kbps(kilobits per second)
    /// KBps(kilobytes per second)
    /// Mbps(megabits per second)
    /// MBps(megabytes per second)
    /// Gbps(gigabits per second)
    /// GBps(gigabytes per second)
    /// Tbps(terabits per second)
    /// TBps(terabytes per second)
    /// </summary>
    [JsonPropertyName("up")]
    public string? Up { get; set; }

    /// <summary>
    /// up, in Mbps.
    /// </summary>
    [JsonPropertyName("up_mbps")]
    public int? UpMbps { get; set; }

    /// <summary>
    /// Format: [Integer] [Unit] e.g. 100 Mbps, 640 KBps, 2 Gbps.
    /// Supported units (case sensitive, b = bits, B = bytes, 8b=1B):
    /// bps (bits per second)
    /// Bps(bytes per second)
    /// Kbps(kilobits per second)
    /// KBps(kilobytes per second)
    /// Mbps(megabits per second)
    /// MBps(megabytes per second)
    /// Gbps(gigabits per second)
    /// GBps(gigabytes per second)
    /// Tbps(terabits per second)
    /// TBps(terabytes per second)
    /// </summary>
    [JsonPropertyName("down")]
    public string? Down { get; set; }

    /// <summary>
    /// down, in Mbps.
    /// </summary>
    [JsonPropertyName("down_mbps")]
    public int? DownMbps { get; set; }

    /// <summary>
    /// Obfuscated password.
    /// </summary>
    [JsonPropertyName("obfs")]
    public string? Obfs { get; set; }

    /// <summary>
    /// Authentication password, in base64.
    /// </summary>
    [JsonPropertyName("auth")]
    public string? Auth { get; set; }

    /// <summary>
    /// Authentication password.
    /// </summary>
    [JsonPropertyName("auth_str")]
    public string? AuthString { get; set; }

    /// <summary>
    /// The QUIC stream-level flow control window for receiving data.
    /// 15728640 (15 MB/s) will be used if empty.
    /// </summary>
    [JsonPropertyName("recv_window_conn")]
    public int? RecvWindowConn { get; set; }

    /// <summary>
    /// The QUIC connection-level flow control window for receiving data.
    /// 67108864 (64 MB/s) will be used if empty.
    /// </summary>
    [JsonPropertyName("recv_window")]
    public int? RecvWindow { get; set; }

    /// <summary>
    /// Disables Path MTU Discovery (RFC 8899). Packets will then be at most 1252 (IPv4) / 1232 (IPv6) bytes in size.
    /// Force enabled on for systems other than Linux and Windows (according to upstream).
    /// </summary>
    [JsonPropertyName("disable_mtu_discovery")]
    public bool? DisableMtuDiscovery { get; set; }

    /// <summary>
    /// One of tcp udp.
    /// Both is enabled by default.
    /// </summary>
    [JsonPropertyName("network")]
    public string? Network { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#outbound">TLS</see>.
    /// </summary>
    [JsonPropertyName("tls")]
    public OutboundTlsConfig? Tls { get; set; }
}