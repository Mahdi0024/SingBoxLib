using System.Text.Json.Serialization;

namespace SingBoxLib.Runtime.Api.Clash.Models;

/// <summary>
/// Represents a Clash API log record.
/// </summary>
public class LogInfo
{
    /// <summary>
    /// Gets or sets the log level.
    /// </summary>
    [JsonPropertyName("level")]
    public string Level { get; set; } = null!;

    /// <summary>
    /// Gets or sets the log message payload.
    /// </summary>
    [JsonPropertyName("payload")]
    public string Payload { get; set; } = null!;
}
