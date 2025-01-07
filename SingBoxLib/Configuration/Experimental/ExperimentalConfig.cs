namespace SingBoxLib.Configuration.Experimental;

public sealed class ExperimentalConfig
{
    [JsonProperty("cache_file")]
    public CacheFile? CacheFile { get; set; }

    [JsonProperty("clash_api")]
    public ClashApi? ClashApi { get; set; }

    [JsonProperty("v2ray_api")]
    public V2rayApi? V2rayApi { get; set; }
}