namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a single DNS server configuration.
/// </summary>
public sealed class DnsServer
{
    /// <summary>
    /// The type of the DNS server.
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The tag of the DNS server.
    /// </summary>
    [JsonProperty("tag")]
    public string? Tag { get; set; }

    /// <summary>
    /// The address of the DNS server.
    /// </summary>
    [JsonProperty("server")]
    public string? Server { get; set; }

    /// <summary>
    /// The port of the DNS server.
    /// </summary>
    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

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
    /// Append an edns0-subnet OPT extra record with the specified IP prefix to every query by default.
    /// </summary>
    [JsonProperty("client_subnet")]
    public string? ClientSubnet { get; set; }

    /// <summary>
    /// TLS configuration for DoT / DoH.
    /// </summary>
    [JsonProperty("tls")]
    public OutboundTlsConfig? Tls { get; set; }

    #region Dial Fields
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
    /// Enable TCP Multi Path.
    /// </summary>
    [JsonProperty("tcp_multi_path")]
    public bool? TcpMultiPath { get; set; }

    /// <summary>
    /// Enable UDP fragmentation.
    /// </summary>
    [JsonProperty("udp_fragment")]
    public bool? UdpFragment { get; set; }

    /// <summary>
    /// Connect timeout.
    /// </summary>
    [JsonProperty("connect_timeout")]
    public string? ConnectTimeout { get; set; }

    /// <summary>
    /// Domain resolver.
    /// </summary>
    [JsonProperty("domain_resolver")]
    public object? DomainResolver { get; set; }

    /// <summary>
    /// Fallback network types when preferred networks are unavailable or timeout.
    /// </summary>
    [JsonProperty("fallback_network_type")]
    public string[]? FallbackNetworkType { get; set; }

    /// <summary>
    /// Fallback delay.
    /// </summary>
    [JsonProperty("fallback_delay")]
    public string? FallbackDelay { get; set; }
    #endregion
}
