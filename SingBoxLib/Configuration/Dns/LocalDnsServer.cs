namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a local DNS server configuration.
/// </summary>
public sealed class LocalDnsServer : DnsServerWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LocalDnsServer"/> class.
    /// </summary>
    public LocalDnsServer()
    {
        Type = "local";
    }

    /// <summary>
    /// When enabled, local DNS server will resolve DNS by dialing itself whenever possible.
    /// </summary>
    [JsonPropertyName("prefer_go")]
    public bool? PreferGo { get; set; }

    /// <summary>
    /// Suffixes for which queries are answered from neighbor resolver.
    /// </summary>
    [JsonPropertyName("neighbor_domain")]
    public List<string>? NeighborDomain { get; set; }
}
