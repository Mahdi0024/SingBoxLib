namespace SingBoxLib.Configuration.Dns.Abstract;

/// <summary>
/// Represents a DNS server configuration with dial fields.
/// </summary>
public abstract class DnsServerWithDialFields : DnsServer
{
    /// <summary>
    /// Tag of an outbound for connecting to the DNS server.
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
    /// Enable TCP Multi Path.
    /// </summary>
    [JsonPropertyName("tcp_multi_path")]
    public bool? TcpMultiPath { get; set; }

    /// <summary>
    /// Enable UDP fragmentation.
    /// </summary>
    [JsonPropertyName("udp_fragment")]
    public bool? UdpFragment { get; set; }

    /// <summary>
    /// Connect timeout.
    /// </summary>
    [JsonPropertyName("connect_timeout")]
    public string? ConnectTimeout { get; set; }

    /// <summary>
    /// Domain resolver.
    /// </summary>
    [JsonPropertyName("domain_resolver")]
    public object? DomainResolver { get; set; }

    /// <summary>
    /// Network types to use when using default or hybrid network strategy.
    /// </summary>
    [JsonPropertyName("network_type")]
    public string[]? NetworkType { get; set; }

    /// <summary>
    /// Fallback network types when preferred networks are unavailable.
    /// </summary>
    [JsonPropertyName("fallback_network_type")]
    public string[]? FallbackNetworkType { get; set; }

    /// <summary>
    /// Fallback delay.
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
