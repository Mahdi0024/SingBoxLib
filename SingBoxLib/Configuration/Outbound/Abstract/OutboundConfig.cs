namespace SingBoxLib.Configuration.Outbound.Abstract;

/// <summary>
/// Represents the base class for outbound configurations.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(DirectOutbound), "direct")]
[JsonDerivedType(typeof(HttpOutbound), "http")]
[JsonDerivedType(typeof(HysteriaOutbound), "hysteria")]
[JsonDerivedType(typeof(Hysteria2Outbound), "hysteria2")]
[JsonDerivedType(typeof(SelectorOutbound), "selector")]
[JsonDerivedType(typeof(ShadowsocksOutbound), "shadowsocks")]
[JsonDerivedType(typeof(ShadowTlsOutbound), "shadowtls")]
[JsonDerivedType(typeof(SocksOutbound), "socks")]
[JsonDerivedType(typeof(SshOutbound), "ssh")]
[JsonDerivedType(typeof(TorOutbound), "tor")]
[JsonDerivedType(typeof(TrojanOutbound), "trojan")]
[JsonDerivedType(typeof(TuicOutbound), "tuic")]
[JsonDerivedType(typeof(UrlTestOutbound), "urltest")]
[JsonDerivedType(typeof(VLessOutbound), "vless")]
[JsonDerivedType(typeof(VMessOutbound), "vmess")]
public abstract class OutboundConfig
{
    /// <summary>
    /// Gets or sets the outbound type.
    /// </summary>
    [JsonIgnore]
    public string? Type { get; internal set; }

    /// <summary>
    /// Gets or sets the unique tag for the outbound.
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }
}