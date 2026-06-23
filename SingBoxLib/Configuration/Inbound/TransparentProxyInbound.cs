namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents a transparent proxy (TProxy) inbound configuration.
/// </summary>
public sealed class TransparentProxyInbound : InboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TransparentProxyInbound"/> class.
    /// </summary>
    /// <param name="tag">The optional inbound tag.</param>
    public TransparentProxyInbound(string? tag = null)
    {
        Type = "tproxy";
        Tag = tag ?? "tproxy-in";
    }
    /// <summary>
    /// Listen network, can be <b>tcp</b> or <b>udp</b>.
    /// Both if empty.
    /// </summary>
    [JsonProperty("network")]
    public string? Network { get; set; }
}