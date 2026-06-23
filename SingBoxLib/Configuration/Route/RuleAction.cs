namespace SingBoxLib.Configuration.Route;

/// <summary>
/// Represents the action to perform when a route rule matches.
/// </summary>
public sealed class RuleAction
{
    /// <summary>
    /// Gets or sets the action type (e.g., "route", "reject", "dns").
    /// </summary>
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    /// <summary>
    /// Gets or sets the target outbound tag.
    /// </summary>
    [JsonPropertyName("outbound")]
    public string? Outbound { get; set; }

    /// <summary>
    /// Gets or sets the override address.
    /// </summary>
    [JsonPropertyName("override_address")]
    public string? OverrideAddress { get; set; }

    /// <summary>
    /// Gets or sets the override port.
    /// </summary>
    [JsonPropertyName("override_port")]
    public int? OverridePort { get; set; }

    /// <summary>
    /// Gets or sets the network strategy.
    /// </summary>
    [JsonPropertyName("network_strategy")]
    public string? NetworkStrategy { get; set; }

    /// <summary>
    /// Gets or sets the fallback delay.
    /// </summary>
    [JsonPropertyName("fallback_delay")]
    public string? FallbackDelay { get; set; }

    /// <summary>
    /// Gets or sets whether to disable UDP domain unmapping.
    /// </summary>
    [JsonPropertyName("udp_disable_domain_unmapping")]
    public bool? UdpDisableDomainUnmapping { get; set; }

    /// <summary>
    /// Gets or sets whether to connect UDP.
    /// </summary>
    [JsonPropertyName("udp_connect")]
    public bool? UdpConnect { get; set; }

    /// <summary>
    /// Gets or sets the UDP timeout.
    /// </summary>
    [JsonPropertyName("udp_timeout")]
    public string? UdpTimeout { get; set; }

    /// <summary>
    /// Gets or sets the HTTP method.
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Gets or sets whether to prevent dropping packets.
    /// </summary>
    [JsonPropertyName("no_drop")]
    public bool? NoDrop { get; set; }

    /// <summary>
    /// Gets or sets the list of sniffers.
    /// </summary>
    [JsonPropertyName("sniffer")]
    public List<string>? Sniffer { get; set; }

    /// <summary>
    /// Gets or sets the connection timeout.
    /// </summary>
    [JsonPropertyName("timeout")]
    public string? Timeout { get; set; }

    /// <summary>
    /// Gets or sets the strategy.
    /// </summary>
    [JsonPropertyName("strategy")]
    public string? Strategy { get; set; }

    /// <summary>
    /// Gets or sets the DNS server tag.
    /// </summary>
    [JsonPropertyName("server")]
    public string? Server { get; set; }
}