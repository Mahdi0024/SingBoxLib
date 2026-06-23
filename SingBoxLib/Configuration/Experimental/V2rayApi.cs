namespace SingBoxLib.Configuration.Experimental;

/// <summary>
/// Configuration for the V2Ray API.
/// </summary>
public sealed class V2rayApi
{
    /// <summary>
    /// gRPC listening address.
    /// </summary>
    [JsonPropertyName("listen")]
    public string? Listen { get; set; }

    /// <summary>
    /// Statistics configuration.
    /// </summary>
    [JsonPropertyName("stats")]
    public Stats? Stats { get; set; }
}

/// <summary>
/// Statistics service configuration.
/// </summary>
public sealed class Stats
{
    /// <summary>
    /// Enable statistics.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// List of inbound tags to collect statistics.
    /// </summary>
    [JsonPropertyName("inbounds")]
    public List<string>? Inbounds { get; set; }

    /// <summary>
    /// List of outbound tags to collect statistics.
    /// </summary>
    [JsonPropertyName("outbounds")]
    public List<string>? Outbounds { get; set; }

    /// <summary>
    /// List of users to collect statistics.
    /// </summary>
    [JsonPropertyName("users")]
    public List<string>? Users { get; set; }
}