namespace SingBoxLib.Configuration.Outbound.Abstract;


/// <summary>
/// Represents an abstract configuration class for outbound connections with dial fields.
/// </summary>
public abstract class OutboundWithDialFields : OutboundConfig
{
    /// <summary>
    /// The tag of the upstream outbound. If enabled, all other fields will be ignored.
    /// </summary>
    [JsonPropertyName("detour")]
    public string? Detour { get; set; }

    /// <summary>
    /// The network interface to bind to.
    /// </summary>
    [JsonPropertyName("bind_interface")]
    public string? BindInterface { get; set; }

    /// <summary>
    /// The IPv4 address to bind to.
    /// </summary>
    [JsonPropertyName("inet4_bind_address")]
    public string? INet4BindAddress { get; set; }

    /// <summary>
    /// The IPv6 address to bind to.
    /// </summary>
    [JsonPropertyName("inet6_bind_address")]
    public string? INet6BindAddress { get; set; }

    /// <summary>
    /// Only supported on Linux. Set netfilter routing mark.
    /// </summary>
    [JsonPropertyName("routing_mark")]
    public int? RoutingMark { get; set; }

    /// <summary>
    /// Reuse listener address.
    /// </summary>
    [JsonPropertyName("reuse_addr")]
    public bool? ReuseAddress { get; set; }

    /// <summary>
    /// Enable TCP Fast Open.
    /// </summary>
    [JsonPropertyName("tcp_fast_open")]
    public bool? TcpFastOpen { get; set; }

    /// <summary>
    /// Enable TCP Multi Path. Go 1.21 required.
    /// </summary>
    [JsonPropertyName("tcp_multi_path")]
    public bool? TcpMultiPath { get; set; }

    /// <summary>
    /// Enable UDP fragmentation.
    /// </summary>
    [JsonPropertyName("udp_fragment")]
    public bool? UdpFragment { get; set; }

    /// <summary>
    /// Connect timeout, in golang's Duration format. A duration string is a possibly signed sequence of decimal numbers,
    /// each with optional fraction and a unit suffix, such as "300ms", "-1.5h" or "2h45m". Valid time units are
    /// "ns", "us" (or "µs"), "ms", "s", "m", "h".
    /// </summary>
    [JsonPropertyName("connect_timeout")]
    public string? ConnectTimeout { get; set; }

    /// <summary>
    /// Domain resolver.
    /// </summary>
    [JsonPropertyName("domain_resolver")]
    public object? DomainResolver { get; set; }

    /// <summary>
    /// Network types to use when using default or hybrid network strategy or preferred network types to
    /// use when using fallback network strategy. Available values: wifi, cellular, ethernet, other.
    /// Device's default network is used by default.
    /// </summary>
    [JsonPropertyName("network_type")]
    public string[]? NetworkType { get; set; }

    /// <summary>
    /// Fallback network types when preferred networks are unavailable or timeout when using fallback
    /// network strategy. All other networks expect preferred are used by default.
    /// </summary>
    [JsonPropertyName("fallback_network_type")]
    public string[]? FallbackNetworkType { get; set; }

    /// <summary>
    /// The length of time to wait before spawning a RFC 6555 Fast Fallback connection. For domain_strategy, is
    /// the amount of time to wait for connection to succeed before assuming that IPv4/IPv6 is misconfigured and
    /// falling back to other type of addresses. For network_strategy, is the amount of time to wait for
    /// connection to succeed before falling back to other interfaces. Only take effect when domain_strategy or
    /// network_strategy is set. 300ms is used by default.
    /// </summary>
    [JsonPropertyName("fallback_delay")]
    public string? FallbackDelay { get; set; }

    /// <summary>
    /// Do not reserve a port when binding to a source address. Only supported on Linux.
    /// </summary>
    [JsonPropertyName("bind_address_no_port")]
    public bool? BindAddressNoPort { get; set; }

    /// <summary>
    /// Set network namespace, name or path. Only supported on Linux.
    /// </summary>
    [JsonPropertyName("netns")]
    public string? Netns { get; set; }

    /// <summary>
    /// Disable TCP keep alive.
    /// </summary>
    [JsonPropertyName("disable_tcp_keep_alive")]
    public bool? DisableTcpKeepAlive { get; set; }

    /// <summary>
    /// TCP keep alive initial period.
    /// </summary>
    [JsonPropertyName("tcp_keep_alive")]
    public string? TcpKeepAlive { get; set; }

    /// <summary>
    /// TCP keep alive interval.
    /// </summary>
    [JsonPropertyName("tcp_keep_alive_interval")]
    public string? TcpKeepAliveInterval { get; set; }
}
