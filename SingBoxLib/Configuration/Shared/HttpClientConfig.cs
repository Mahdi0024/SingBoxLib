using System.Collections.Generic;
using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Outbound.Shared;

namespace SingBoxLib.Configuration.Shared;

/// <summary>
/// Represents top-level HTTP client configuration.
/// </summary>
public sealed class HttpClientConfig
{
    /// <summary>
    /// The tag of the HTTP client.
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    /// <summary>
    /// HTTP engine to use (e.g. go, apple).
    /// </summary>
    [JsonPropertyName("engine")]
    public string? Engine { get; set; }

    /// <summary>
    /// HTTP version (1, 2, 3).
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// Disable automatic fallback to lower HTTP version.
    /// </summary>
    [JsonPropertyName("disable_version_fallback")]
    public bool? DisableVersionFallback { get; set; }

    /// <summary>
    /// Custom HTTP headers.
    /// </summary>
    [JsonPropertyName("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// TLS configuration.
    /// </summary>
    [JsonPropertyName("tls")]
    public OutboundTlsConfig? Tls { get; set; }

    #region Dial Fields
    /// <summary>
    /// The tag of the upstream outbound.
    /// </summary>
    [JsonPropertyName("detour")]
    public string? Detour { get; set; }

    /// <summary>
    /// Egress interface name.
    /// </summary>
    [JsonPropertyName("bind_interface")]
    public string? BindInterface { get; set; }

    /// <summary>
    /// Egress IPv4 address.
    /// </summary>
    [JsonPropertyName("inet4_bind_address")]
    public string? INet4BindAddress { get; set; }

    /// <summary>
    /// Egress IPv6 address.
    /// </summary>
    [JsonPropertyName("inet6_bind_address")]
    public string? INet6BindAddress { get; set; }

    /// <summary>
    /// Do not reserve a port when binding to a source address.
    /// </summary>
    [JsonPropertyName("bind_address_no_port")]
    public bool? BindAddressNoPort { get; set; }

    /// <summary>
    /// Set netfilter routing mark.
    /// </summary>
    [JsonPropertyName("routing_mark")]
    public int? RoutingMark { get; set; }

    /// <summary>
    /// Reuse listener address.
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

    /// <summary>
    /// Enable UDP fragmentation.
    /// </summary>
    [JsonPropertyName("udp_fragment")]
    public bool? UdpFragment { get; set; }

    /// <summary>
    /// Domain resolver.
    /// </summary>
    [JsonPropertyName("domain_resolver")]
    public object? DomainResolver { get; set; }

    /// <summary>
    /// Strategy for selecting network interfaces.
    /// </summary>
    [JsonPropertyName("network_strategy")]
    public string? NetworkStrategy { get; set; }

    /// <summary>
    /// Network types.
    /// </summary>
    [JsonPropertyName("network_type")]
    public string[]? NetworkType { get; set; }

    /// <summary>
    /// Fallback network types.
    /// </summary>
    [JsonPropertyName("fallback_network_type")]
    public string[]? FallbackNetworkType { get; set; }

    /// <summary>
    /// Fallback delay.
    /// </summary>
    [JsonPropertyName("fallback_delay")]
    public string? FallbackDelay { get; set; }
    #endregion
}