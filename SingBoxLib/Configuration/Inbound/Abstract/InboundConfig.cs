namespace SingBoxLib.Configuration.Inbound.Abstract;

public abstract class InboundConfig
{
    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("tag")]
    public string? Tag { get; set; }

    [JsonProperty("listen")]
    public string? Listen { get; set; }

    [JsonProperty("listen_port")]
    public int? ListenPort { get; set; }

    [JsonProperty("tcp_fast_open")]
    public bool? TcpFastOpen { get; set; }

    [JsonProperty("tcp_multi_path")]
    public bool? TcpMultiPath { get; set; }

    [JsonProperty("udp_fragment")]
    public bool? UdpFragment { get; set; }

    [JsonProperty("sniff")]
    public bool? Sniff { get; set; }

    [JsonProperty("sniff_override_destination")]
    public bool? SniffOverrideDestination { get; set; }

    [JsonProperty("sniff_timeout")]
    public string? SniffTimeout { get; set; }

    [JsonProperty("domain_stategy")]
    public string? DomainStategy { get; set; }

    [JsonProperty("udp_timeout")]
    public int? UdpTimeout { get; set; }

    [JsonProperty("proxy_protocol")]
    public bool? ProxyProtocol { get; set; }

    [JsonProperty("proxy_protocol_accept_no_header")]
    public bool? ProxyProtocolAcceptNoHeader { get; set; }

    [JsonProperty("detour")]
    public string? Detour { get; set; }
}