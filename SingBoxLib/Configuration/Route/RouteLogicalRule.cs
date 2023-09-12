namespace SingBoxLib.Configuration.Route;

public sealed class RouteLogicalRule
{
    [JsonProperty("type")]
    public string? Type { get; } = "logical";

    /// <summary>
    /// can be "and" or  "or"
    /// </summary>
    [JsonProperty("mode")]
    public string? Mode { get; set; }

    [JsonProperty("rules")]
    public List<object>? Rules { get; set; }

    [JsonProperty("invert")]
    public bool? Invert { get; set; }

    [JsonProperty("outbound")]
    public string? Outbound { get; set; }
}