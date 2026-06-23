namespace SingBoxLib.Configuration.Route;
public sealed class RouteRuleSetLocal : RouteRuleSetBase
{
    public RouteRuleSetLocal()
    {
        Type = "local";
    }
    [JsonProperty("format")]
    public required string Format { get; set; }

    [JsonProperty("path")]
    public required string Path { get; set; }
}
