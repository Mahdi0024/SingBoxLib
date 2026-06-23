namespace SingBoxLib.Configuration.Experimental;

/// <summary>
/// Configuration for the Clash API.
/// </summary>
public sealed class ClashApi
{
    /// <summary>
    /// RESTful web API listening address.
    /// </summary>
    [JsonPropertyName("external_controller")]
    public string? ExternalController { get; set; }

    /// <summary>
    /// Relative or absolute path to static web resources directory to serve at /ui.
    /// </summary>
    [JsonPropertyName("external_ui")]
    public string? ExternalUi { get; set; }

    /// <summary>
    /// ZIP download URL for the external UI.
    /// </summary>
    [JsonPropertyName("external_ui_download_url")]
    public string? ExternalUiDownloadUrl { get; set; }

    /// <summary>
    /// The tag of the outbound to download the external UI.
    /// </summary>
    [JsonPropertyName("external_ui_download_detour")]
    public string? ExternalUiDownloadDetour { get; set; }

    /// <summary>
    /// Secret key for RESTful API authentication.
    /// </summary>
    [JsonPropertyName("secret")]
    public string? Secret { get; set; }

    /// <summary>
    /// Default mode in Clash.
    /// </summary>
    [JsonPropertyName("default_mode")]
    public string? DefaultMode { get; set; }

    /// <summary>
    /// CORS allowed origins.
    /// </summary>
    [JsonPropertyName("access_control_allow_origin")]
    public string[]? AccessControlAllowOrigin { get; set; }

    /// <summary>
    /// Allow private network access to the API.
    /// </summary>
    [JsonPropertyName("access_control_allow_private_network")]
    public bool AccessControlAllowPrivateNetwork { get; set; }
}