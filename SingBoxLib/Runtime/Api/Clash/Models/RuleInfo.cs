using System.Text.Json.Serialization;

namespace SingBoxLib.Runtime.Api.Clash.Models;

/// <summary>
/// Represents Clash rule configuration details.
/// </summary>
public class RuleInfo
{
    /// <summary>
    /// Gets or sets the rule type.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    /// <summary>
    /// Gets or sets the rule matching payload.
    /// </summary>
    [JsonPropertyName("payload")]
    public string Payload { get; set; } = null!;

    /// <summary>
    /// Gets or sets the target proxy/outbound tag.
    /// </summary>
    [JsonPropertyName("proxy")]
    public string Proxy { get; set; } = null!;
}
