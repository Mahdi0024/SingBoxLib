namespace SingBoxLib.Configuration.Route;

public sealed class RouteConfig
{
    [JsonProperty("geoip")]
    public GeoIPConfig? GeoIP { get; set; }

    [JsonProperty("geosite")]
    public GeositeConfig? Geosite { get; set; }

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

    /// <summary>
    /// Rule object can be of type RouteRule or RouteLogicalRule
    /// </summary>
    [JsonProperty("rules")]
    public List<object>? Rules { get; set; }
}