namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents the configuration for DNS resolution.
/// </summary>
public sealed class DnsConfig
{
    /// <summary>
    /// A list of DNS servers to use for resolution.
    /// </summary>
    [JsonPropertyName("servers")]
    public List<DnsServer>? Servers { get; set; }

    /// <summary>
    /// A list of rules for DNS resolution.
    /// </summary>
    [JsonPropertyName("rules")]
    public List<DnsRuleBase>? Rules { get; set; }

    /// <summary>
    /// Default DNS server tag. The first server will be used if empty.
    /// </summary>
    [JsonPropertyName("final")]
    public string? Final { get; set; }

    /// <summary>
    /// Default domain strategy for resolving the domain names. 
    /// One of: prefer_ipv4, prefer_ipv6, ipv4_only, ipv6_only. See <see cref="DnsStrategy"/>
    /// Takes no effect if server.strategy is set.
    /// </summary>
    [JsonPropertyName("strategy")]
    public string? Strategy { get; set; }

    /// <summary>
    /// Disable DNS cache.
    /// </summary>
    [JsonPropertyName("disable_cache")]
    public bool? DisableCache { get; set; }

    /// <summary>
    /// Disable DNS cache expire.
    /// </summary>
    [JsonPropertyName("disable_expire")]
    public bool? DisableExpire { get; set; }

    /// <summary>
    /// LRU cache capacity. 
    /// Value less than 1024 will be ignored.
    /// </summary>
    [JsonPropertyName("cache_capacity")]
    public int? CacheCapacity { get; set; }

    /// <summary>
    /// Stores a reverse mapping of IP addresses after responding to a DNS query 
    /// in order to provide domain names when routing. 
    /// Since this process relies on the act of resolving domain names by an 
    /// application before making a request, it can be problematic in environments 
    /// such as macOS, where DNS is proxied and cached by the system.
    /// </summary>
    [JsonPropertyName("reverse_mapping")]
    public bool? ReverseMapping { get; set; }

    /// <summary>
    /// Append an edns0-subnet OPT extra record with the specified IP prefix 
    /// to every query by default. 
    /// If value is an IP address instead of prefix, /32 or /128 will be 
    /// appended automatically. 
    /// Can be overrided by Servers[].ClientSubnet or Rules[].ClientSubnet.
    /// </summary>
    [JsonPropertyName("client_subnet")]
    public string? ClientSubnet { get; set; }

    /// <summary>
    /// Fake IP configuration.
    /// </summary>
    [JsonPropertyName("fakeip")]
    public FakeIp? Fakeip { get; set; }

    /// <summary>
    /// Enable optimistic DNS caching. Can be bool or DnsOptimisticConfig object.
    /// </summary>
    [JsonPropertyName("optimistic")]
    public object? Optimistic { get; set; }

    /// <summary>
    /// Default timeout for each DNS query.
    /// </summary>
    [JsonPropertyName("timeout")]
    public string? Timeout { get; set; }
}
/// <summary>
/// Constants representing DNS domain strategy.
/// </summary>
public static class DnsStrategy
{
    /// <summary>
    /// Prefer resolving IPv4 addresses.
    /// </summary>
    public const string PreferIpv4 = "prefer_ipv4";

    /// <summary>
    /// Prefer resolving IPv6 addresses.
    /// </summary>
    public const string PreferIpv6 = "prefer_ipv6";

    /// <summary>
    /// Resolve IPv4 addresses only.
    /// </summary>
    public const string Ipv4Only = "ipv4_only";

    /// <summary>
    /// Resolve IPv6 addresses only.
    /// </summary>
    public const string Ipv6Only = "ipv6_only";
}