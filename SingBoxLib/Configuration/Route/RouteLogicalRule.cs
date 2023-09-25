using SingBoxLib.Configuration.Converters;
using SingBoxLib.Configuration.Route.Abstract;

namespace SingBoxLib.Configuration.Route;

public sealed class RouteLogicalRule : RouteRuleBase
{
    [JsonProperty("type")]
    public string? Type { get; } = "logical";

    /// <summary>
    /// can be "and" or  "or"
    /// </summary>
    [JsonProperty("mode")]
    public string? Mode { get; set; }

    [JsonConverter(typeof(RouteRuleJsonConverter))]
    [JsonProperty("rules")]
    public List<RouteRuleBase>? Rules { get; set; }

    [JsonProperty("invert")]
    public bool? Invert { get; set; }

    [JsonProperty("outbound")]
    public string? Outbound { get; set; }
}