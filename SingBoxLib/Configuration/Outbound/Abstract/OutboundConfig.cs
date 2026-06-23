namespace SingBoxLib.Configuration.Outbound.Abstract;

/// <summary>
/// Represents the base class for outbound configurations.
/// </summary>
public abstract class OutboundConfig
{
    /// <summary>
    /// Gets or sets the outbound type.
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; internal set; }

    /// <summary>
    /// Gets or sets the unique tag for the outbound.
    /// </summary>
    [JsonProperty("tag")]
    public string? Tag { get; set; }
}