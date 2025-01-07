namespace SingBoxLib.Configuration.Experimental;
public class CacheFile
{
    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    [JsonProperty("path")]
    public string? Path { get; set; }

    [JsonProperty("cache_id")]
    public string? CacheId { get; set; }

    [JsonProperty("store_fakeip")]
    public bool StoreFakeIp { get; set; }

    [JsonProperty("store_rdrc")]
    public bool StoreRdrc { get; set; }

    [JsonProperty("rdrc_timeout")]
    public string? RdrcTimeout { get; set; }
}
