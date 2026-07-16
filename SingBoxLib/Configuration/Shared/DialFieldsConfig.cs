using System.Text.Json.Serialization;

namespace SingBoxLib.Configuration.Shared;

/// <summary>
/// Represents shared dial fields.
/// </summary>
public sealed class DialFieldsConfig
{
    /// <summary>
    /// Tag of target outbound.
    /// </summary>
    [JsonPropertyName("detour")]
    public string? Detour { get; set; }

    /// <summary>
    /// Interface name.
    /// </summary>
    [JsonPropertyName("bind_interface")]
    public string? BindInterface { get; set; }

    /// <summary>
    /// IPv4 bind address.
    /// </summary>
    [JsonPropertyName("inet4_bind_address")]
    public string? INet4BindAddress { get; set; }

    /// <summary>
    /// IPv6 bind address.
    /// </summary>
    [JsonPropertyName("inet6_bind_address")]
    public string? INet6BindAddress { get; set; }

    /// <summary>
    /// Bind address no port.
    /// </summary>
    [JsonPropertyName("bind_address_no_port")]
    public bool? BindAddressNoPort { get; set; }

    /// <summary>
    /// Routing mark.
    /// </summary>
    [JsonPropertyName("routing_mark")]
    public int? RoutingMark { get; set; }

    /// <summary>
    /// Reuse address.
    /// </summary>
    [JsonPropertyName("reuse_addr")]
    public bool? ReuseAddress { get; set; }

    /// <summary>
    /// Network namespace.
    /// </summary>
    [JsonPropertyName("netns")]
    public string? Netns { get; set; }

    /// <summary>
    /// Connect timeout.
    /// </summary>
    [JsonPropertyName("connect_timeout")]
    public string? ConnectTimeout { get; set; }

    /// <summary>
    /// TCP Fast Open.
    /// </summary>
    [JsonPropertyName("tcp_fast_open")]
    public bool? TcpFastOpen { get; set; }

    /// <summary>
    /// TCP Multi Path.
    /// </summary>
    [JsonPropertyName("tcp_multi_path")]
    public bool? TcpMultiPath { get; set; }

    /// <summary>
    /// Disable TCP keep alive.
    /// </summary>
    [JsonPropertyName("disable_tcp_keep_alive")]
    public bool? DisableTcpKeepAlive { get; set; }

    /// <summary>
    /// TCP keep alive.
    /// </summary>
    [JsonPropertyName("tcp_keep_alive")]
    public string? TcpKeepAlive { get; set; }

    /// <summary>
    /// TCP keep alive interval.
    /// </summary>
    [JsonPropertyName("tcp_keep_alive_interval")]
    public string? TcpKeepAliveInterval { get; set; }

    /// <summary>
    /// UDP fragment.
    /// </summary>
    [JsonPropertyName("udp_fragment")]
    public bool? UdpFragment { get; set; }

    /// <summary>
    /// Domain resolver.
    /// </summary>
    [JsonPropertyName("domain_resolver")]
    public object? DomainResolver { get; set; }

    /// <summary>
    /// Network strategy.
    /// </summary>
    [JsonPropertyName("network_strategy")]
    public string? NetworkStrategy { get; set; }

    /// <summary>
    /// Network type.
    /// </summary>
    [JsonPropertyName("network_type")]
    public string[]? NetworkType { get; set; }

    /// <summary>
    /// Fallback network type.
    /// </summary>
    [JsonPropertyName("fallback_network_type")]
    public string[]? FallbackNetworkType { get; set; }

    /// <summary>
    /// Fallback delay.
    /// </summary>
    [JsonPropertyName("fallback_delay")]
    public string? FallbackDelay { get; set; }
}