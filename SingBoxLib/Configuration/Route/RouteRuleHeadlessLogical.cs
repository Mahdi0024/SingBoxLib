namespace SingBoxLib.Configuration.Route;
internal class RouteRuleHeadlessLogical : RouteRuleHeadlessBase
{
    public RouteRuleHeadlessLogical()
    {
        Type = "logical";
    }

    [JsonPropertyName("type")]
    public string? Type { get; internal set; }

    [JsonPropertyName("mode")]
    public required string Mode { get; set; }

    [JsonPropertyName("rules")]
    public List<RouteRuleBase>? Rules { get; set; }

    [JsonPropertyName("invert")]
    public bool? Invert { get; set; }
}
