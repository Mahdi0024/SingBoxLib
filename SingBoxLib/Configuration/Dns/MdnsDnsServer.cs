namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents an mDNS DNS server configuration.
/// </summary>
public sealed class MdnsDnsServer : DnsServerWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MdnsDnsServer"/> class.
    /// </summary>
    public MdnsDnsServer()
    {
        Type = "mdns";
    }

    /// <summary>
    /// List of network interface names to send mDNS queries on.
    /// </summary>
    [JsonPropertyName("interface")]
    public List<string>? Interface { get; set; }
}
