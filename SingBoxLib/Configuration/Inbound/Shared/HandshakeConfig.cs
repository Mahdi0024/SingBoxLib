namespace SingBoxLib.Configuration.Inbound.Shared;

public class HandshakeConfig
{
    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("detour")]
    public string? Detour { get; set; }

    [JsonProperty("bind_interface")]
    public string? BindInterface { get; set; }

    [JsonProperty("inet4_bind_address")]
    public string? INet4BindAddress { get; set; }

    [JsonProperty("inet6_bind_address")]
    public string? INet6BindAddress { get; set; }

    [JsonProperty("routing_mark")]
    public int? RoutingMark { get; set; }

    [JsonProperty("reuse_addr")]
    public bool? ReuseAddress { get; set; }

    [JsonProperty("connect_timeout")]
    public string? ConnectTimeout { get; set; }

    [JsonProperty("tcp_fast_open")]
    public bool? TcpFastOpen { get; set; }

    [JsonProperty("tcp_multi_path")]
    public bool? TcpMultiPath { get; set; }

    [JsonProperty("udp_fragment")]
    public bool? UdpFragment { get; set; }

    [JsonProperty("domain_strategy")]
    public string? DomainStrategy { get; set; }

    [JsonProperty("fallback_delay")]
    public string? FallbackDelay { get; set; }
}
