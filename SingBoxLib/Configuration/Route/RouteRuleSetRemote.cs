namespace SingBoxLib.Configuration.Route;
/// <summary>
/// Represents a remote rule-set configuration.
/// </summary>
public sealed class RouteRuleSetRemote : RouteRuleSetBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RouteRuleSetRemote"/> class.
    /// </summary>
    public RouteRuleSetRemote()
    {
        Type = "remote";
    }

    /// <summary>
    /// Format of the rule-set (e.g. source, binary).
    /// </summary>
    [JsonPropertyName("format")]
    public required string Format { get; set; }

    /// <summary>
    /// URL to download the remote rule-set.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// Tag of the HTTP client used to download the remote rule-set.
    /// </summary>
    [JsonPropertyName("http_client")]
    public string? HttpClient { get; set; }

    /// <summary>
    /// Update interval for the remote rule-set.
    /// </summary>
    [JsonPropertyName("update_interval")]
    public string? UpdateInterval { get; set; }
}
