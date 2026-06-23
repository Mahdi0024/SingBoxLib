namespace SingBoxLib.Configuration.Experimental;

/// <summary>
/// Configuration for experimental features.
/// </summary>
public sealed class ExperimentalConfig
{
    /// <summary>
    /// Configuration for cache-file features.
    /// </summary>
    [JsonProperty("cache_file")]
    public CacheFile? CacheFile { get; set; }

    /// <summary>
    /// Configuration for Clash API.
    /// </summary>
    [JsonProperty("clash_api")]
    public ClashApi? ClashApi { get; set; }

    /// <summary>
    /// Configuration for V2Ray API.
    /// </summary>
    [JsonProperty("v2ray_api")]
    public V2rayApi? V2rayApi { get; set; }
}