namespace SingBoxLib.Configuration.Route;

/// <summary>
/// Represents the configuration for the routing service.
/// </summary>
public sealed class RouteConfig
{
    /// <summary>
    /// List of routing rules. Rule objects can be of type RouteRule or RouteLogicalRule.
    /// </summary>
    [JsonPropertyName("rules")]
    public List<RouteRuleBase>? Rules { get; set; }

    /// <summary>
    /// List of rule-set configurations.
    /// </summary>
    [JsonPropertyName("rule_set")]
    public List<RouteRuleSetBase>? RuleSet { get; set; }

    /// <summary>
    /// Default outbound tag. The first outbound will be used if empty.
    /// </summary>
    [JsonPropertyName("final")]
    public string? Final { get; set; }

    /// <summary>
    /// Automatically detects the default network interface.
    /// </summary>
    [JsonPropertyName("auto_detect_interface")]
    public bool? AutoDetectInterface { get; set; }

    /// <summary>
    /// Overrides Android VPN settings.
    /// </summary>
    [JsonPropertyName("override_android_vpn")]
    public bool? OverrideAndroidVpn { get; set; }

    /// <summary>
    /// The default network interface to bind.
    /// </summary>
    [JsonPropertyName("default_interface")]
    public string? DefaultInterface { get; set; }

    /// <summary>
    /// The default netfilter routing mark.
    /// </summary>
    [JsonPropertyName("default_mark")]
    public int? DefaultMark { get; set; }

    /// <summary>
    /// The default network strategy.
    /// </summary>
    [JsonPropertyName("default_network_strategy")]
    public string? DefaultNetworkStrategy { get; set; }

    /// <summary>
    /// The default network types to use.
    /// </summary>
    [JsonPropertyName("default_network_type")]
    public List<string>? DefaultNetworkType { get; set; }

    /// <summary>
    /// The default fallback network types.
    /// </summary>
    [JsonPropertyName("default_fallback_network_type")]
    public List<string>? DefaultFallbackNetworkType { get; set; }

    /// <summary>
    /// The default fallback delay.
    /// </summary>
    [JsonPropertyName("default_fallback_delay")]
    public string? DefaultFallbackDelay { get; set; }

    /// <summary>
    /// The default HTTP client.
    /// </summary>
    [JsonPropertyName("default_http_client")]
    public string? DefaultHttpClient { get; set; }

    /// <summary>
    /// The default domain resolver.
    /// </summary>
    [JsonPropertyName("default_domain_resolver")]
    public object? DefaultDomainResolver { get; set; }

    /// <summary>
    /// Enable process search for logging.
    /// </summary>
    [JsonPropertyName("find_process")]
    public bool? FindProcess { get; set; }

    /// <summary>
    /// Since 1.14.0. Enable neighbor resolution for logging.
    /// </summary>
    [JsonPropertyName("find_neighbor")]
    public bool? FindNeighbor { get; set; }

    /// <summary>
    /// Since 1.14.0. Custom DHCP lease file paths.
    /// </summary>
    [JsonPropertyName("dhcp_lease_files")]
    public List<string>? DhcpLeaseFiles { get; set; }
}