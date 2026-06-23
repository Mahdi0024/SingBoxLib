namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents a URL-test outbound configuration.
/// </summary>
public sealed class UrlTestOutbound : OutboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UrlTestOutbound"/> class.
    /// </summary>
    /// <param name="tag">The optional outbound tag.</param>
    public UrlTestOutbound(string? tag = null)
    {
        Type = "urltest";
        Tag = tag ?? "auto";
    }

    /// <summary>
    /// List of outbound tags to test.
    /// </summary>
    [JsonProperty("outbounds")]
    public List<string>? Outbounds { get; set; }

    /// <summary>
    /// The URL to test. https://www.gstatic.com/generate_204 will be used if empty.
    /// </summary>
    [JsonProperty("url")]
    public string? Url { get; set; }

    /// <summary>
    /// The test interval. 3m will be used if empty.
    /// </summary>
    [JsonProperty("interval")]
    public string? Interval { get; set; }

    /// <summary>
    /// The test tolerance in milliseconds. 50 will be used if empty.
    /// </summary>
    [JsonProperty("tolerance")]
    public int? Tolerance { get; set; }

    /// <summary>
    /// The idle timeout. 30m will be used if empty.
    /// </summary>
    [JsonProperty("idle_timeout")]
    public string? IdleTimeout { get; set; }

    /// <summary>
    /// Interrupt existing connections when the selected outbound has changed.
    /// Only inbound connections are affected by this setting, internal connections will always be interrupted.
    /// </summary>
    [JsonProperty("interrupt_exist_connections")]
    public bool? InterruptExistConnections { get; set; }

}