namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// The selector can only be controlled through the Clash API currently.
/// </summary>
public sealed class SelectorOutbound : OutboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SelectorOutbound"/> class.
    /// </summary>
    /// <param name="tag">The optional outbound tag.</param>
    public SelectorOutbound(string? tag = null)
    {
        Type = "selector";
        Tag = tag ?? "selector-out";
    }

    /// <summary>
    /// List of outbound tags to select.
    /// </summary>
    [JsonProperty("outbounds")]
    public required List<string>? Outbounds { get; set; }

    /// <summary>
    /// The default outbound tag. The first outbound will be used if empty.
    /// </summary>
    [JsonProperty("default")]
    public string? Default { get; set; }

    /// <summary>
    /// Interrupt existing connections when the selected outbound has changed.
    /// Only inbound connections are affected by this setting, internal connections will always be interrupted.
    /// </summary>
    [JsonProperty("interrupt_exist_connections")]
    public bool? InterruptExistConnections { get; set; }
}