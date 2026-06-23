namespace SingBoxLib.Configuration.Experimental;
/// <summary>
/// Configuration for the experimental cache-file feature.
/// </summary>
public sealed class CacheFile
{
    /// <summary>
    /// Enable cache file.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    /// <summary>
    /// Path to the cache file.
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Identifier in the cache file.
    /// </summary>
    [JsonPropertyName("cache_id")]
    public string? CacheId { get; set; }

    /// <summary>
    /// Store FakeIP in the cache file.
    /// </summary>
    [JsonPropertyName("store_fakeip")]
    public bool StoreFakeIp { get; set; }

    /// <summary>
    /// Store DNS cache in the cache file.
    /// </summary>
    [JsonPropertyName("store_dns")]
    public bool StoreDns { get; set; }
}
