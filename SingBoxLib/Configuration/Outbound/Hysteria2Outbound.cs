using SingboxLib.Configuration.Outbound.Shared;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a Hysteria 2 outbound.
/// </summary>
public sealed class Hysteria2Outbound : OutboundWithDialFields
{
    public Hysteria2Outbound(string? tag = null)
    {
        Type = "hysteria2";
        Tag = tag ?? "hysteria2-out";
    }

    /// <summary>
    /// The server address.
    /// </summary>
    [JsonProperty("server")]
    public required string Server { get; set; }

    /// <summary>
    /// The server port.
    /// Ignored if server_ports is set.
    /// </summary>
    [JsonProperty("server_port")]
    public int ServerPort { get; set; }

    /// <summary>
    /// Server port range list.
    /// Example: 2080:3000
    /// </summary>
    [JsonProperty("server_ports")]
    public List<string>? ServerPorts { get; set; }

    /// <summary>
    /// Port hopping interval.
    /// 30s is used by default.
    /// </summary>
    [JsonProperty("hop_interval")]
    public string? HopInterval { get; set; }

    /// <summary>
    /// Max bandwidth, in Mbps.
    /// If empty, the BBR congestion control algorithm will be used instead of Hysteria CC.
    /// </summary>
    [JsonProperty("up_mbps")]
    public int? UpMbps { get; set; }

    /// <summary>
    /// Max bandwidth, in Mbps.
    /// If empty, the BBR congestion control algorithm will be used instead of Hysteria CC.
    /// </summary>
    [JsonProperty("down_mbps")]
    public int? DownMbps { get; set; }

    /// <summary>
    /// traffic obfuscator configuration.
    /// </summary>
    [JsonProperty("obfs")]
    public Hysteria2Obfs? Obfs { get; set; }

    /// <summary>
    /// Authentication password.
    /// </summary>
    [JsonProperty("password")]
    public string? Password { get; set; }

    /// <summary>
    /// One of tcp udp.
    /// Both is enabled by default.
    /// </summary>
    [JsonProperty("network")]
    public string? Network { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#outbound">TLS</see>.
    /// </summary>
    [JsonProperty("tls")]
    public OutboundTlsConfig? Tls { get; set; }
}