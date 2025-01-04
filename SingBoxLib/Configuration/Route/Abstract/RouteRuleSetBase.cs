namespace SingboxLib.Configuration.Route.Abstract;

public abstract class RouteRuleSetBase
{
    [JsonProperty("type")]
    public string Type { get; internal set; } = default!;

    [JsonProperty("tag")]
    public required string Tag { get; set; }
}