using SingBoxLib.Configuration.Inbound.Abstract;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents a direct inbound configuration.
/// </summary>
public sealed class DirectInbound : InboundConfig
{
    public DirectInbound(string? tag = null)
    {
        Type = "direct";
        Tag = tag ?? "direct-in";
    }
    /// <summary>
    /// Listen network, can be tcp or udp. Both if empty.
    /// </summary>
    [JsonProperty("network")]
    public string? Network { get; set; }

    /// <summary>
    /// Override the connection destination address.
    /// </summary>
    [JsonProperty("override_address")]
    public string? OverrideAddress { get; set; }

    /// <summary>
    /// Override the connection destination port.
    /// </summary>
    [JsonProperty("override_port")]
    public int? OverridePort { get; set; }
}