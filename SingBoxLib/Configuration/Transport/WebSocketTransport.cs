namespace SingBoxLib.Configuration.Transport;

/// <summary>
/// Represents a WebSocket transport configuration.
/// </summary>
public sealed class WebSocketTransport : TransportConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WebSocketTransport"/> class.
    /// </summary>
    public WebSocketTransport()
    {
        Type = "ws";
    }

    /// <summary>
    /// Gets or sets the WebSocket connection path.
    /// </summary>
    [JsonProperty("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Gets or sets the custom WebSocket headers.
    /// </summary>
    [JsonProperty("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// Gets or sets the maximum size of early data.
    /// </summary>
    [JsonProperty("max_early_data")]
    public int? MaxEarlyData { get; set; }

    /// <summary>
    /// Gets or sets the name of the early data header.
    /// </summary>
    [JsonProperty("early_data_header_name")]
    public string? EarlyDataHeaderName { get; set; }
}