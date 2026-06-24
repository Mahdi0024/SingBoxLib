using System.Text.Json.Serialization;

namespace SingBoxLib.Runtime.Api.Clash.Models;

/// <summary>
/// Represents proxy connection delay information.
/// </summary>
public class ProxyDelayInfo
{
    /// <summary>
    /// Gets or sets the delay/latency in milliseconds.
    /// </summary>
    [JsonPropertyName("delay")]
    public int Delay { get; set; }

    /// <summary>
    /// Gets or sets whether the latency test was successful.
    /// </summary>
    public bool Success { get; set; }
}
