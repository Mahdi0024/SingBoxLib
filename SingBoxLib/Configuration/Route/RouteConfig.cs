namespace SingBoxLib.Configuration.Route;

/// <summary>
/// Represents the configuration for the routing service.
/// </summary>
public sealed class RouteConfig
{
    /// <summary>
    /// List of routing rules. Rule objects can be of type RouteRule or RouteLogicalRule.
    /// </summary>
    [JsonProperty("rules")]
    public List<RouteRuleBase>? Rules { get; set; }

    /// <summary>
    /// List of rule-set configurations.
    /// </summary>
    [JsonProperty("rule_set")]
    public List<RouteRuleSetBase>? RuleSet { get; set; }

    /// <summary>
    /// Default outbound tag. The first outbound will be used if empty.
    /// </summary>
    [JsonProperty("final")]
    public string? Final { get; set; }

    /// <summary>
    /// Automatically detects the default network interface.
    /// </summary>
    [JsonProperty("auto_detect_interface")]
    public bool? AutoDetectInterface { get; set; }

    /// <summary>
    /// Overrides Android VPN settings.
    /// </summary>
    [JsonProperty("override_android_vpn")]
    public bool? OverrideAndroidVpn { get; set; }

    /// <summary>
    /// The default network interface to bind.
    /// </summary>
    [JsonProperty("default_interface")]
    public string? DefaultInterface { get; set; }

    /// <summary>
    /// The default netfilter routing mark.
    /// </summary>
    [JsonProperty("default_mark")]
    public int? DefaultMark { get; set; }

    /// <summary>
    /// The default network strategy.
    /// </summary>
    [JsonProperty("default_network_strategy")]
    public string? DefaultNetworkStrategy { get; set; }

    /// <summary>
    /// The default network types to use.
    /// </summary>
    [JsonProperty("default_network_type")]
    public List<string>? DefaultNetworkType { get; set; }

    /// <summary>
    /// The default fallback network types.
    /// </summary>
    [JsonProperty("default_fallback_network_type")]
    public List<string>? DefaultFallbackNetworkType { get; set; }

    /// <summary>
    /// The default fallback delay.
    /// </summary>
    [JsonProperty("default_fallback_delay")]
    public string? DefaultFallbackDelay { get; set; }
}