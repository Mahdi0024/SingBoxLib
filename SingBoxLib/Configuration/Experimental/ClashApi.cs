namespace SingBoxLib.Configuration.Experimental;

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

    [JsonProperty("access_control_allow_origin")]
    public string[]? AccessControlAllowOrigin { get; set; }

    [JsonProperty("access_control_allow_private_network")]
    public bool AccessControlAllowPrivateNetwork { get; set; }
}