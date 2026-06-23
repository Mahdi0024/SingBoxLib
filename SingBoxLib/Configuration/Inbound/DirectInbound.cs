namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents a direct inbound configuration.
/// </summary>
public sealed class DirectInbound : InboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DirectInbound"/> class.
    /// </summary>
    /// <param name="tag">The optional inbound tag.</param>
    public DirectInbound(string? tag = null)
    {
        Type = "direct";
        Tag = tag ?? "direct-in";
    }
    /// <summary>
    /// Listen network, can be tcp or udp. Both if empty.
    /// </summary>
    [JsonPropertyName("network")]
    public string? Network { get; set; }

    /// <summary>
    /// Override the connection destination address.
    /// </summary>
    [JsonPropertyName("override_address")]
    public string? OverrideAddress { get; set; }

    /// <summary>
    /// Override the connection destination port.
    /// </summary>
    [JsonPropertyName("override_port")]
    public int? OverridePort { get; set; }
}