namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a single DNS server configuration.
/// </summary>
public sealed class DnsServer
{
    /// <summary>
    /// The tag of the DNS server.
    /// </summary>
    [JsonProperty("tag")]
    public string? Tag { get; set; }

    /// <summary>
    /// The address of the DNS server.
    /// </summary>
    [JsonProperty("address")]
    public required string Address { get; set; }

    /// <summary>
    /// Required if address contains domain. 
    /// Tag of another server to resolve the domain name in the address.
    /// </summary>
    [JsonProperty("address_resolver")]
    public string? AddressResolver { get; set; }

    /// <summary>
    /// The domain strategy for resolving the domain name in the address.
    /// One of: prefer_ipv4, prefer_ipv6, ipv4_only, ipv6_only.
    /// dns.strategy will be used if empty.
    /// </summary>
    [JsonProperty("address_strategy")]
    public string? AddressStrategy { get; set; }

    /// <summary>
    /// Default domain strategy for resolving the domain names.
    /// One of: prefer_ipv4, prefer_ipv6, ipv4_only, ipv6_only.
    /// Takes no effect if overridden by other settings.
    /// </summary>
    [JsonProperty("strategy")]
    public string? Strategy { get; set; }

    /// <summary>
    /// Tag of an outbound for connecting to the DNS server.
    /// Default outbound will be used if empty.
    /// </summary>
    [JsonProperty("detour")]
    public string? Detour { get; set; }

    /// <summary>
    /// Since sing-box 1.9.0.
    /// Append an edns0-subnet OPT extra record with the specified IP prefix to every query by default.
    /// If value is an IP address instead of prefix, /32 or /128 will be appended automatically.
    /// Can be overrides by rules[].client_subnet.
    /// Will overrides dns.client_subnet.
    /// </summary>
    [JsonProperty("client_subnet")]
    public string? ClientSubnet { get; set; }
}