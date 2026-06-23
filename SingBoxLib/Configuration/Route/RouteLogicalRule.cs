namespace SingBoxLib.Configuration.Route;

/// <summary>
/// Represents a logical rule for routing.
/// </summary>
public sealed class RouteLogicalRule : RouteRuleBase
{
    /// <summary>
    /// Gets the type of route rule, which is logical.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; } = "logical";

    /// <summary>
    /// Gets or sets the logical evaluation mode (e.g., and, or).
    /// </summary>
    [JsonPropertyName("mode")]
    public string? Mode { get; set; }

    /// <summary>
    /// Gets or sets the list of nested route rules.
    /// </summary>
    [JsonPropertyName("rules")]
    public List<RouteRuleBase>? Rules { get; set; }

    /// <summary>
    /// Gets or sets whether to invert the rule match.
    /// </summary>
    [JsonPropertyName("invert")]
    public bool? Invert { get; set; }

    /// <summary>
    /// Gets or sets the target outbound tag.
    /// </summary>
    [JsonPropertyName("outbound")]
    public string? Outbound { get; set; }
}