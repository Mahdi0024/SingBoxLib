namespace SingBoxLib.Configuration.Route;

public class RuleAction
{
    [JsonProperty("action")]
    public string? Action { get; set; }

    [JsonProperty("outbound")]
    public string? Outbound { get; set; }

    [JsonProperty("override_address")]
    public string? OverrideAddress { get; set; }

    [JsonProperty("override_port")]
    public int? OverridePort { get; set; }

    [JsonProperty("network_strategy")]
    public string? NetworkStrategy { get; set; }

    [JsonProperty("fallback_delay")]
    public string? FallbackDelay { get; set; }

    [JsonProperty("udp_disable_domain_unmapping")]
    public bool? UdpDisableDomainUnmapping { get; set; }

    [JsonProperty("udp_connect")]
    public bool? UdpConnect { get; set; }

    [JsonProperty("udp_timeout")]
    public string? UdpTimeout { get; set; }

    [JsonProperty("method")]
    public string? Method { get; set; }

    [JsonProperty("no_drop")]
    public bool? NoDrop { get; set; }

    [JsonProperty("sniffer")]
    public List<string>? Sniffer { get; set; }

    [JsonProperty("timeout")]
    public string? Timeout { get; set; }

    [JsonProperty("strategy")]
    public string? Strategy { get; set; }

    [JsonProperty("server")]
    public string? Server { get; set; }
}