namespace SingBoxLib.Configuration.Route.Abstract;

/// <summary>
/// Represents the base class for route rule-sets.
/// </summary>
[JsonDerivedType(typeof(RouteRuleSetInline))]
[JsonDerivedType(typeof(RouteRuleSetLocal))]
[JsonDerivedType(typeof(RouteRuleSetRemote))]
public abstract class RouteRuleSetBase
{
    /// <summary>
    /// Gets or sets the rule-set type.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; } = default!;

    /// <summary>
    /// Gets or sets the unique tag for the rule-set.
    /// </summary>
    [JsonPropertyName("tag")]
    public required string Tag { get; set; }
}