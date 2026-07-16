namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a FakeIP DNS server configuration.
/// </summary>
public sealed class FakeIpDnsServer : DnsServer
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FakeIpDnsServer"/> class.
    /// </summary>
    public FakeIpDnsServer()
    {
        Type = "fakeip";
    }

    /// <summary>
    /// IPv4 address range for FakeIP.
    /// </summary>
    [JsonPropertyName("inet4_range")]
    public string? Inet4Range { get; set; }

    /// <summary>
    /// IPv6 address range for FakeIP.
    /// </summary>
    [JsonPropertyName("inet6_range")]
    public string? Inet6Range { get; set; }
}
