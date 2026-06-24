namespace SingBoxLib.Configuration.Experimental;

/// <summary>
/// Configuration for experimental features.
/// </summary>
public sealed class ExperimentalConfig
{
    /// <summary>
    /// Configuration for cache-file features.
    /// </summary>
    [JsonPropertyName("cache_file")]
    public CacheFile? CacheFile { get; set; }

    /// <summary>
    /// Configuration for Clash API.
    /// </summary>
    [JsonPropertyName("clash_api")]
    public ClashApi? ClashApi { get; set; }

    /// <summary>
    /// Configuration for sing-box native/gRPC API.
    /// </summary>
    [JsonPropertyName("api")]
    public V2rayApi? Api { get; set; }
}