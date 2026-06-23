namespace SingBoxLib.Configuration.Route;
/// <summary>
/// Represents a local route rule-set configuration.
/// </summary>
public sealed class RouteRuleSetLocal : RouteRuleSetBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RouteRuleSetLocal"/> class.
    /// </summary>
    public RouteRuleSetLocal()
    {
        Type = "local";
    }

    /// <summary>
    /// Gets or sets the format of the local rule-set.
    /// </summary>
    [JsonProperty("format")]
    public required string Format { get; set; }

    /// <summary>
    /// Gets or sets the file path of the local rule-set.
    /// </summary>
    [JsonProperty("path")]
    public required string Path { get; set; }
}
