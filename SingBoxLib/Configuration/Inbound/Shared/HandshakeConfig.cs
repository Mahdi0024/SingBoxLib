namespace SingBoxLib.Configuration.Inbound.Shared;

/// <summary>
/// Represents configuration for dialer/handshake settings.
/// </summary>
public sealed class HandshakeConfig
{
    /// <summary>
    /// Server address.
    /// </summary>
    [JsonProperty("server")]
    public string? Server { get; set; }

    /// <summary>
    /// Server port.
    /// </summary>
    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    /// <summary>
    /// Tag of the detour outbound connection.
    /// </summary>
    [JsonProperty("detour")]
    public string? Detour { get; set; }

    /// <summary>
    /// The network interface to bind.
    /// </summary>
    [JsonProperty("bind_interface")]
    public string? BindInterface { get; set; }

    /// <summary>
    /// IPv4 address to bind.
    /// </summary>
    [JsonProperty("inet4_bind_address")]
    public string? INet4BindAddress { get; set; }

    /// <summary>
    /// IPv6 address to bind.
    /// </summary>
    [JsonProperty("inet6_bind_address")]
    public string? INet6BindAddress { get; set; }

    /// <summary>
    /// Netfilter routing mark.
    /// </summary>
    [JsonProperty("routing_mark")]
    public int? RoutingMark { get; set; }

    /// <summary>
    /// Reuse listener address.
    /// </summary>
    [JsonProperty("reuse_addr")]
    public bool? ReuseAddress { get; set; }

    /// <summary>
    /// Connection timeout.
    /// </summary>
    [JsonProperty("connect_timeout")]
    public string? ConnectTimeout { get; set; }

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
    /// Domain resolver.
    /// </summary>
    [JsonProperty("domain_resolver")]
    public object? DomainResolver { get; set; }

    /// <summary>
    /// Fallback delay.
    /// </summary>
    [JsonProperty("fallback_delay")]
    public string? FallbackDelay { get; set; }
}
