using System.Text.Json.Serialization;

namespace SingBoxLib.Runtime.Api.Clash.Models;

/// <summary>
/// Represents Clash connection traffic metrics.
/// </summary>
public class TrafficInfo
{
    /// <summary>
    /// Gets or sets the uploaded bytes.
    /// </summary>
    [JsonPropertyName("up")]
    public int Up { get; set; }

    /// <summary>
    /// Gets or sets the downloaded bytes.
    /// </summary>
    [JsonPropertyName("down")]
    public int Down { get; set; }
}
