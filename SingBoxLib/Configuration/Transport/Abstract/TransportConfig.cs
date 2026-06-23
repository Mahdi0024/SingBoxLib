namespace SingBoxLib.Configuration.Transport.Abstract;

/// <summary>
/// Represents the base class for V2Ray transport configurations.
/// </summary>
public abstract class TransportConfig
{
    /// <summary>
    /// Gets or sets the transport type.
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }
}