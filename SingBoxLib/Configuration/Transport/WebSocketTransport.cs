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
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Gets or sets the custom WebSocket headers.
    /// </summary>
    [JsonPropertyName("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// Gets or sets the maximum size of early data.
    /// </summary>
    [JsonPropertyName("max_early_data")]
    public int? MaxEarlyData { get; set; }

    /// <summary>
    /// Gets or sets the name of the early data header.
    /// </summary>
    [JsonPropertyName("early_data_header_name")]
    public string? EarlyDataHeaderName { get; set; }
}