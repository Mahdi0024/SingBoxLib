namespace SingBoxLib.Configuration.Experimantal;

public sealed class ClashApi
{
    [JsonProperty("external_controller")]
    public string? ExternalController { get; set; }

    [JsonProperty("external_ui")]
    public string? ExternalUi { get; set; }

    [JsonProperty("external_ui_download_url")]
    public string? ExternalUiDownloadUrl { get; set; }

    [JsonProperty("external_ui_download_detour")]
    public string? ExternalUiDownloadDetour { get; set; }

    [JsonProperty("secret")]
    public string? Secret { get; set; }

    [JsonProperty("default_mode")]
    public string? DefaultMode { get; set; }

    [JsonProperty("store_mode")]
    public bool? StoreMode { get; set; }

    [JsonProperty("store_selected")]
    public bool? StoreSelected { get; set; }

    [JsonProperty("store_fakeip")]
    public bool? StoreFakeip { get; set; }

    [JsonProperty("cache_file")]
    public string? CacheFile { get; set; }

    [JsonProperty("cache_id")]
    public string? CacheId { get; set; }
}