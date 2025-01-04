using SingBoxLib.Configuration.Converters;
using SingBoxLib.Configuration.Dns.Abstract;

namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents the configuration for DNS resolution.
/// </summary>
public sealed class DnsConfig
{
    /// <summary>
    /// A list of DNS servers to use for resolution.
    /// </summary>
    [JsonProperty("servers")]
    public List<DnsServer>? Servers { get; set; }

    /// <summary>
    /// A list of rules for DNS resolution.
    /// </summary>
    [JsonConverter(typeof(DnsRuleJsonConverter))]
    [JsonProperty("rules")]
    public List<DnsRuleBase>? Rules { get; set; }

    /// <summary>
    /// Default DNS server tag. The first server will be used if empty.
    /// </summary>
    [JsonProperty("final")]
    public string? Final { get; set; }

    /// <summary>
    /// Default domain strategy for resolving the domain names. 
    /// One of: prefer_ipv4, prefer_ipv6, ipv4_only, ipv6_only. See <see cref="DnsStrategy"/>
    /// Takes no effect if server.strategy is set.
    /// </summary>
    [JsonProperty("strategy")]
    public string? Strategy { get; set; }

    /// <summary>
    /// Disable DNS cache.
    /// </summary>
    [JsonProperty("disable_cache")]
    public bool? DisableCache { get; set; }

    /// <summary>
    /// Disable DNS cache expire.
    /// </summary>
    [JsonProperty("disable_expire")]
    public bool? DisableExpire { get; set; }

    /// <summary>
    /// Make each DNS server's cache independent for special purposes. 
    /// If enabled, will slightly degrade performance.
    /// </summary>
    [JsonProperty("independent_cache")]
    public bool? IndependentCache { get; set; }

    /// <summary>
    /// LRU cache capacity. 
    /// Value less than 1024 will be ignored.
    /// </summary>
    [JsonProperty("cache_capacity")]
    public int? CacheCapacity { get; set; }

    /// <summary>
    /// Stores a reverse mapping of IP addresses after responding to a DNS query 
    /// in order to provide domain names when routing. 
    /// Since this process relies on the act of resolving domain names by an 
    /// application before making a request, it can be problematic in environments 
    /// such as macOS, where DNS is proxied and cached by the system.
    /// </summary>
    [JsonProperty("reverse_mapping")]
    public bool? ReverseMapping { get; set; }

    /// <summary>
    /// Append an edns0-subnet OPT extra record with the specified IP prefix 
    /// to every query by default. 
    /// If value is an IP address instead of prefix, /32 or /128 will be 
    /// appended automatically. 
    /// Can be overrided by Servers[].ClientSubnet or Rules[].ClientSubnet.
    /// </summary>
    [JsonProperty("client_subnet")]
    public string? ClientSubnet { get; set; }

    /// <summary>
    /// Fake IP configuration.
    /// </summary>
    [JsonProperty("fakeip")]
    public FakeIp? Fakeip { get; set; }
}
public static class DnsStrategy
{
    public const string PreferIpv4 = "prefer_ipv4";
    public const string PreferIpv6 = "prefer_ipv6";
    public const string Ipv4Only = "ipv4_only";
    public const string Ipv6Only = "ipv6_only";
}