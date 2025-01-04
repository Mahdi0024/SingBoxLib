namespace SingBoxLib.Configuration.Inbound.Abstract;

public abstract class InboundConfig
{
    [JsonProperty("type")]
    public string? Type { get; internal set; }

    [JsonProperty("tag")]
    public string? Tag { get; set; }

    /// <summary>
    /// Listen address.
    /// </summary>
    [JsonProperty("listen")]
    public required string Listen { get; set; }

    /// <summary>
    /// Listen port.
    /// </summary>
    [JsonProperty("listen_port")]
    public required int ListenPort { get; set; }

    /// <summary>
    /// Enable TCP Fast Open.
    /// </summary>
    [JsonProperty("tcp_fast_open")]
    public bool? TcpFastOpen { get; set; }

    /// <summary>
    /// Enable TCP Multi Path.
    /// </summary>
    [JsonProperty("tcp_multi_path")]
    public bool? TcpMultiPath { get; set; }

    /// <summary>
    /// Enable UDP fragmentation.
    /// </summary>
    [JsonProperty("udp_fragment")]
    public bool? UdpFragment { get; set; }

    /// <summary>
    /// UDP NAT expiration time.
    /// 5m will be used by default.
    /// </summary>
    [JsonProperty("udp_timeout")]
    public int? UdpTimeout { get; set; }

    /// <summary>
    /// If set, connections will be forwarded to the specified inbound.]
    /// Requires target inbound support, see <see href="http://sing-box.sagernet.org/configuration/inbound/#fields">Injectable</see>.
    /// </summary>
    [JsonProperty("detour")]
    public string? Detour { get; set; }
}