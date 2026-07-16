namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Configuration options for optimistic DNS caching.
/// </summary>
public sealed class DnsOptimisticConfig
{
    /// <summary>
    /// Enable optimistic DNS caching.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    /// <summary>
    /// The maximum time an expired cache entry can be served optimistically.
    /// </summary>
    [JsonPropertyName("timeout")]
    public string? Timeout { get; set; }
}
