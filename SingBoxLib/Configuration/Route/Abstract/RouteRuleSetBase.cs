namespace SingBoxLib.Configuration.Route.Abstract;

/// <summary>
/// Represents the base class for route rule-sets.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(RouteRuleSetInline), "inline")]
[JsonDerivedType(typeof(RouteRuleSetLocal), "local")]
[JsonDerivedType(typeof(RouteRuleSetRemote), "remote")]
public abstract class RouteRuleSetBase
{
    /// <summary>
    /// Gets or sets the rule-set type.
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; } = default!;

    /// <summary>
    /// Gets or sets the unique tag for the rule-set.
    /// </summary>
    [JsonPropertyName("tag")]
    public required string Tag { get; set; }
}