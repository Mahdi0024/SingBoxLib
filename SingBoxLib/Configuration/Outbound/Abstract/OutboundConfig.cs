namespace SingBoxLib.Configuration.Outbound.Abstract;

/// <summary>
/// Represents the base class for outbound configurations.
/// </summary>
[JsonDerivedType(typeof(DirectOutbound))]
[JsonDerivedType(typeof(HttpOutbound))]
[JsonDerivedType(typeof(HysteriaOutbound))]
[JsonDerivedType(typeof(Hysteria2Outbound))]
[JsonDerivedType(typeof(SelectorOutbound))]
[JsonDerivedType(typeof(ShadowsocksOutbound))]
[JsonDerivedType(typeof(ShadowTlsOutbound))]
[JsonDerivedType(typeof(SocksOutbound))]
[JsonDerivedType(typeof(SshOutbound))]
[JsonDerivedType(typeof(TorOutbound))]
[JsonDerivedType(typeof(TrojanOutbound))]
[JsonDerivedType(typeof(TuicOutbound))]
[JsonDerivedType(typeof(UrlTestOutbound))]
[JsonDerivedType(typeof(VLessOutbound))]
[JsonDerivedType(typeof(VMessOutbound))]
public abstract class OutboundConfig
{
    /// <summary>
    /// Gets or sets the outbound type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; internal set; }

    /// <summary>
    /// Gets or sets the unique tag for the outbound.
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }
}