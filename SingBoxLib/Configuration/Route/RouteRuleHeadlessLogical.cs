using System.Collections.Generic;
using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Route.Abstract;

namespace SingBoxLib.Configuration.Route;

/// <summary>
/// Represents a headless route rule logical configuration.
/// </summary>
public class RouteRuleHeadlessLogical : RouteRuleHeadlessBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RouteRuleHeadlessLogical"/> class.
    /// </summary>
    public RouteRuleHeadlessLogical()
    {
        Type = "logical";
    }

    /// <summary>
    /// Gets or sets the route rule type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; internal set; }

    /// <summary>
    /// Gets or sets the logical evaluation mode (e.g. and, or).
    /// </summary>
    [JsonPropertyName("mode")]
    public required string Mode { get; set; }

    /// <summary>
    /// Gets or sets the nested route rules.
    /// </summary>
    [JsonPropertyName("rules")]
    public List<RouteRuleBase>? Rules { get; set; }

    /// <summary>
    /// Gets or sets whether to invert the rule match.
    /// </summary>
    [JsonPropertyName("invert")]
    public bool? Invert { get; set; }
}
