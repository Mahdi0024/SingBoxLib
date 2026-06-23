namespace SingBoxLib.Configuration.Route;
/// <summary>
/// Represents an inline route rule-set configuration.
/// </summary>
public sealed class RouteRuleSetInline : RouteRuleSetBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RouteRuleSetInline"/> class.
    /// </summary>
    public RouteRuleSetInline()
    {
        Type = "inline";
    }

    /// <summary>
    /// Gets or sets the list of inline rules.
    /// </summary>
    [JsonProperty("rules")]
    public required List<RouteRuleHeadlessBase> Rules { get; set; }
}
