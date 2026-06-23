namespace SingBoxLib.Configuration.Experimental;

/// <summary>
/// Configuration for the V2Ray API.
/// </summary>
public sealed class V2rayApi
{
    /// <summary>
    /// gRPC listening address.
    /// </summary>
    [JsonProperty("listen")]
    public string? Listen { get; set; }

    /// <summary>
    /// Statistics configuration.
    /// </summary>
    [JsonProperty("stats")]
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
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// List of inbound tags to collect statistics.
    /// </summary>
    [JsonProperty("inbounds")]
    public List<string>? Inbounds { get; set; }

    /// <summary>
    /// List of outbound tags to collect statistics.
    /// </summary>
    [JsonProperty("outbounds")]
    public List<string>? Outbounds { get; set; }

    /// <summary>
    /// List of users to collect statistics.
    /// </summary>
    [JsonProperty("users")]
    public List<string>? Users { get; set; }
}