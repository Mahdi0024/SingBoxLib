namespace SingBoxLib.Configuration.Inbound.Abstract;

/// <summary>
/// Represents the base class for inbound configurations.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(DirectInbound), "direct")]
[JsonDerivedType(typeof(HttpInbound), "http")]
[JsonDerivedType(typeof(HysteriaInbound), "hysteria")]
[JsonDerivedType(typeof(Hysteria2Inbound), "hysteria2")]
[JsonDerivedType(typeof(MixedInbound), "mixed")]
[JsonDerivedType(typeof(NaiveInbound), "naive")]
[JsonDerivedType(typeof(RedirectInbound), "redirect")]
[JsonDerivedType(typeof(ShadowsocksInbound), "shadowsocks")]
[JsonDerivedType(typeof(ShadowTlsInbound), "shadowtls")]
[JsonDerivedType(typeof(SocksInbound), "socks")]
[JsonDerivedType(typeof(TransparentProxyInbound), "tproxy")]
[JsonDerivedType(typeof(TrojanInbound), "trojan")]
[JsonDerivedType(typeof(TuicInbound), "tuic")]
[JsonDerivedType(typeof(TunInbound), "tun")]
[JsonDerivedType(typeof(VLessInbound), "vless")]
[JsonDerivedType(typeof(VMessInbound), "vmess")]
public abstract class InboundConfig
{
    /// <summary>
    /// Gets or sets the inbound type.
    /// </summary>
    [JsonIgnore]
    public string? Type { get; internal set; }

    /// <summary>
    /// Gets or sets the unique tag for the inbound.
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    /// <summary>
    /// Listen address.
    /// </summary>
    [JsonPropertyName("listen")]
    public string? Listen { get; set; }

    /// <summary>
    /// Listen port.
    /// </summary>
    [JsonPropertyName("listen_port")]
    public int? ListenPort { get; set; }

    /// <summary>
    /// Enable TCP Fast Open.
    /// </summary>
    [JsonPropertyName("tcp_fast_open")]
    public bool? TcpFastOpen { get; set; }

    /// <summary>
    /// Enable TCP Multi Path.
    /// </summary>
    [JsonPropertyName("tcp_multi_path")]
    public bool? TcpMultiPath { get; set; }

    /// <summary>
    /// Enable UDP fragmentation.
    /// </summary>
    [JsonPropertyName("udp_fragment")]
    public bool? UdpFragment { get; set; }

    /// <summary>
    /// UDP NAT expiration time.
    /// 5m will be used by default.
    /// </summary>
    [JsonPropertyName("udp_timeout")]
    public int? UdpTimeout { get; set; }

    /// <summary>
    /// If set, connections will be forwarded to the specified inbound.]
    /// Requires target inbound support, see <see href="http://sing-box.sagernet.org/configuration/inbound/#fields">Injectable</see>.
    /// </summary>
    [JsonPropertyName("detour")]
    public string? Detour { get; set; }
}