namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents the base class for DNS server configurations.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(LocalDnsServer), "local")]
[JsonDerivedType(typeof(HostsDnsServer), "hosts")]
[JsonDerivedType(typeof(TcpDnsServer), "tcp")]
[JsonDerivedType(typeof(UdpDnsServer), "udp")]
[JsonDerivedType(typeof(TlsDnsServer), "tls")]
[JsonDerivedType(typeof(QuicDnsServer), "quic")]
[JsonDerivedType(typeof(HttpsDnsServer), "https")]
[JsonDerivedType(typeof(H3DnsServer), "h3")]
[JsonDerivedType(typeof(DhcpDnsServer), "dhcp")]
[JsonDerivedType(typeof(MdnsDnsServer), "mdns")]
[JsonDerivedType(typeof(FakeIpDnsServer), "fakeip")]
[JsonDerivedType(typeof(TailscaleDnsServer), "tailscale")]
[JsonDerivedType(typeof(ResolvedDnsServer), "resolved")]
public abstract class DnsServer
{
    /// <summary>
    /// Gets or sets the DNS server type.
    /// </summary>
    [JsonIgnore]
    public string? Type { get; internal set; }

    /// <summary>
    /// Gets or sets the unique tag for the DNS server.
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }
}
