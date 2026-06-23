namespace SingBoxLib.Configuration.Route;

/// <summary>
/// Represents the action to perform when a route rule matches.
/// </summary>
public sealed class RuleAction
{
    /// <summary>
    /// Gets or sets the action type (e.g., "route", "reject", "dns").
    /// </summary>
    [JsonProperty("action")]
    public string? Action { get; set; }

    /// <summary>
    /// Gets or sets the target outbound tag.
    /// </summary>
    [JsonProperty("outbound")]
    public string? Outbound { get; set; }

    /// <summary>
    /// Gets or sets the override address.
    /// </summary>
    [JsonProperty("override_address")]
    public string? OverrideAddress { get; set; }

    /// <summary>
    /// Gets or sets the override port.
    /// </summary>
    [JsonProperty("override_port")]
    public int? OverridePort { get; set; }

    /// <summary>
    /// Gets or sets the network strategy.
    /// </summary>
    [JsonProperty("network_strategy")]
    public string? NetworkStrategy { get; set; }

    /// <summary>
    /// Gets or sets the fallback delay.
    /// </summary>
    [JsonProperty("fallback_delay")]
    public string? FallbackDelay { get; set; }

    /// <summary>
    /// Gets or sets whether to disable UDP domain unmapping.
    /// </summary>
    [JsonProperty("udp_disable_domain_unmapping")]
    public bool? UdpDisableDomainUnmapping { get; set; }

    /// <summary>
    /// Gets or sets whether to connect UDP.
    /// </summary>
    [JsonProperty("udp_connect")]
    public bool? UdpConnect { get; set; }

    /// <summary>
    /// Gets or sets the UDP timeout.
    /// </summary>
    [JsonProperty("udp_timeout")]
    public string? UdpTimeout { get; set; }

    /// <summary>
    /// Gets or sets the HTTP method.
    /// </summary>
    [JsonProperty("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Gets or sets whether to prevent dropping packets.
    /// </summary>
    [JsonProperty("no_drop")]
    public bool? NoDrop { get; set; }

    /// <summary>
    /// Gets or sets the list of sniffers.
    /// </summary>
    [JsonProperty("sniffer")]
    public List<string>? Sniffer { get; set; }

    /// <summary>
    /// Gets or sets the connection timeout.
    /// </summary>
    [JsonProperty("timeout")]
    public string? Timeout { get; set; }

    /// <summary>
    /// Gets or sets the strategy.
    /// </summary>
    [JsonProperty("strategy")]
    public string? Strategy { get; set; }

    /// <summary>
    /// Gets or sets the DNS server tag.
    /// </summary>
    [JsonProperty("server")]
    public string? Server { get; set; }
}