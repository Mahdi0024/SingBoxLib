using System.Text.Json.Serialization;

namespace SingBoxLib.Runtime.Api.Clash.Models;

/// <summary>
/// Represents Clash version details.
/// </summary>
public class VersionInfo
{
    /// <summary>
    /// Gets or sets whether Meta features are active.
    /// </summary>
    [JsonPropertyName("meta")]
    public bool Meta { get; set; }

    /// <summary>
    /// Gets or sets whether Premium features are active.
    /// </summary>
    [JsonPropertyName("premium")]
    public bool Premium { get; set; }

    /// <summary>
    /// Gets or sets the version string.
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; set; } = null!;
}
