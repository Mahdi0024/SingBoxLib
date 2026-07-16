using System.Text.Json.Serialization;

namespace SingBoxLib.Configuration.Service.Models;

/// <summary>
/// Web dashboard configuration for the sing-box API service.
/// </summary>
public sealed class ApiServiceDashboardConfig
{
    /// <summary>
    /// Enable the dashboard.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Directory the dashboard files are stored in.
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Download URL of the dashboard archive (zip).
    /// </summary>
    [JsonPropertyName("download_url")]
    public string? DownloadUrl { get; set; }

    /// <summary>
    /// HTTP client used to download the dashboard. Can be string or object.
    /// </summary>
    [JsonPropertyName("http_client")]
    public object? HttpClient { get; set; }

    /// <summary>
    /// Update interval of the dashboard.
    /// </summary>
    [JsonPropertyName("update_interval")]
    public string? UpdateInterval { get; set; }
}