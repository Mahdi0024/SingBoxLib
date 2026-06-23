namespace SingboxLib.Configuration.Route;
public sealed class RouteRuleSetInline : RouteRuleSetBase
{
    public RouteRuleSetInline()
    {
        Type = "inline";
    }
    [JsonProperty("rules")]
    public required List<RouteRuleHeadlessBase> Rules { get; set; }
}
