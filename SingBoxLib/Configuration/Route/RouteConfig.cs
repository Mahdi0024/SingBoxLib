using SingboxLib.Configuration.Route.Abstract;
using SingBoxLib.Configuration.Route.Abstract;

namespace SingBoxLib.Configuration.Route;

public sealed class RouteConfig
{
    /// <summary>
    /// Rule object can be of type RouteRule or RouteLogicalRule
    /// </summary>
    [JsonProperty("rules")]
    public List<RouteRuleBase>? Rules { get; set; }

    [JsonProperty("rule_set")]
    public List<RouteRuleSetBase>? RuleSet { get; set; }

    [JsonProperty("final")]
    public string? Final { get; set; }

    [JsonProperty("auto_detect_interface")]
    public bool? AutoDetectInterface { get; set; }

    [JsonProperty("override_android_vpn")]
    public bool? OverrideAndroidVpn { get; set; }

    [JsonProperty("default_interface")]
    public string? DefaultInterface { get; set; }

    [JsonProperty("default_mark")]
    public int? DefaultMark { get; set; }

    [JsonProperty("default_network_strategy")]
    public string? DefaultNetworkStrategy { get; set; }

    [JsonProperty("default_network_type")]
    public List<string>? DefaultNetworkType { get; set; }

    [JsonProperty("default_fallback_network_type")]
    public List<string>? DefaultFallbackNetworkType { get; set; }

    [JsonProperty("default_fallback_delay")]
    public string? DefaultFallbackDelay { get; set; }
}