namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a DHCP DNS server configuration.
/// </summary>
public sealed class DhcpDnsServer : DnsServerWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DhcpDnsServer"/> class.
    /// </summary>
    public DhcpDnsServer()
    {
        Type = "dhcp";
    }

    /// <summary>
    /// Interface name to listen on.
    /// </summary>
    [JsonPropertyName("interface")]
    public string? Interface { get; set; }
}
