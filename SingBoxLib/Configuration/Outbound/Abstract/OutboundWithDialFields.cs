namespace SingBoxLib.Configuration.Outbound.Abstract;


/// <summary>
/// Represents an abstract configuration class for outbound connections with dial fields.
/// </summary>
public abstract class OutboundWithDialFields : OutboundConfig
{
    /// <summary>
    /// The tag of the upstream outbound. If enabled, all other fields will be ignored.
    /// </summary>
    [JsonProperty("detour")]
    public string? Detour { get; set; }

    /// <summary>
    /// The network interface to bind to.
    /// </summary>
    [JsonProperty("bind_interface")]
    public string? BindInterface { get; set; }

    /// <summary>
    /// The IPv4 address to bind to.
    /// </summary>
    [JsonProperty("inet4_bind_address")]
    public string? INet4BindAddress { get; set; }

    /// <summary>
    /// The IPv6 address to bind to.
    /// </summary>
    [JsonProperty("inet6_bind_address")]
    public string? INet6BindAddress { get; set; }

    /// <summary>
    /// Only supported on Linux. Set netfilter routing mark.
    /// </summary>
    [JsonProperty("routing_mark")]
    public int? RoutingMark { get; set; }

    /// <summary>
    /// Reuse listener address.
    /// </summary>
    [JsonProperty("reuse_addr")]
    public bool? ReuseAddress { get; set; }

    /// <summary>
    /// Enable TCP Fast Open.
    /// </summary>
    [JsonProperty("tcp_fast_open")]
    public bool? TcpFastOpen { get; set; }

    /// <summary>
    /// Enable TCP Multi Path. Go 1.21 required.
    /// </summary>
    [JsonProperty("tcp_multi_path")]
    public bool? TcpMultiPath { get; set; }

    /// <summary>
    /// Enable UDP fragmentation.
    /// </summary>
    [JsonProperty("udp_fragment")]
    public bool? UdpFragment { get; set; }

    /// <summary>
    /// Connect timeout, in golang's Duration format. A duration string is a possibly signed sequence of decimal numbers,
    /// each with optional fraction and a unit suffix, such as "300ms", "-1.5h" or "2h45m". Valid time units are
    /// "ns", "us" (or "µs"), "ms", "s", "m", "h".
    /// </summary>
    [JsonProperty("connect_timeout")]
    public string? ConnectTimeout { get; set; }

    /// <summary>
    /// Domain strategy. Available values: prefer_ipv4, prefer_ipv6, ipv4_only, ipv6_only.
    /// If set, the requested domain name will be resolved to IP before connect.
    /// </summary>
    [JsonProperty("domain_strategy")]
    public string? DomainStrategy { get; set; }

    /// <summary>
    /// Network types to use when using default or hybrid network strategy or preferred network types to
    /// use when using fallback network strategy. Available values: wifi, cellular, ethernet, other.
    /// Device's default network is used by default.
    /// </summary>
    [JsonProperty("network_type")]
    public string[]? NetworkType { get; set; }

    /// <summary>
    /// Fallback network types when preferred networks are unavailable or timeout when using fallback
    /// network strategy. All other networks expect preferred are used by default.
    /// </summary>
    [JsonProperty("fallback_network_type")]
    public string[]? FallbackNetworkType { get; set; }

    /// <summary>
    /// The length of time to wait before spawning a RFC 6555 Fast Fallback connection. For domain_strategy, is
    /// the amount of time to wait for connection to succeed before assuming that IPv4/IPv6 is misconfigured and
    /// falling back to other type of addresses. For network_strategy, is the amount of time to wait for
    /// connection to succeed before falling back to other interfaces. Only take effect when domain_strategy or
    /// network_strategy is set. 300ms is used by default.
    /// </summary>
    [JsonProperty("fallback_delay")]
    public string? FallbackDelay { get; set; }
}
