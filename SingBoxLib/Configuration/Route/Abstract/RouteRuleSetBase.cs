namespace SingBoxLib.Configuration.Route.Abstract;

/// <summary>
/// Represents the base class for route rule-sets.
/// </summary>
public abstract class RouteRuleSetBase
{
    /// <summary>
    /// Gets or sets the rule-set type.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; internal set; } = default!;

    /// <summary>
    /// Gets or sets the unique tag for the rule-set.
    /// </summary>
    [JsonProperty("tag")]
    public required string Tag { get; set; }
}