namespace SingBoxLib.Configuration.Service.Abstract;

/// <summary>
/// Represents an abstract configuration class for services with listen fields.
/// </summary>
public abstract class ServiceWithListenFields : ServiceConfig
{
    /// <summary>
    /// Listen address.
    /// </summary>
    [JsonPropertyName("listen")]
    public string? Listen { get; set; }

    /// <summary>
    /// Listen port.
    /// </summary>
    [JsonPropertyName("listen_port")]
    public int? ListenPort { get; set; }

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
    /// UDP NAT expiration time.
    /// </summary>
    [JsonPropertyName("udp_timeout")]
    public string? UdpTimeout { get; set; }

    /// <summary>
    /// Tag of target detour outbound.
    /// </summary>
    [JsonPropertyName("detour")]
    public string? Detour { get; set; }

    /// <summary>
    /// The network interface to bind to.
    /// </summary>
    [JsonPropertyName("bind_interface")]
    public string? BindInterface { get; set; }

    /// <summary>
    /// Set netfilter routing mark. Only supported on Linux.
    /// </summary>
    [JsonPropertyName("routing_mark")]
    public int? RoutingMark { get; set; }

    /// <summary>
    /// Reuse listener address.
    /// </summary>
    [JsonPropertyName("reuse_addr")]
    public bool? ReuseAddress { get; set; }

    /// <summary>
    /// Set network namespace. Only supported on Linux.
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
