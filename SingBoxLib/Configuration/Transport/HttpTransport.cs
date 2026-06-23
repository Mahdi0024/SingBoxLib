namespace SingBoxLib.Configuration.Transport;

/// <summary>
/// Represents an HTTP transport configuration.
/// </summary>
public sealed class HttpTransport : TransportConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpTransport"/> class.
    /// </summary>
    public HttpTransport()
    {
        Type = "http";
    }

    /// <summary>
    /// Gets or sets the host header.
    /// </summary>
    [JsonPropertyName("host")]
    public string? Host { get; set; }

    /// <summary>
    /// Gets or sets the HTTP request path.
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Gets or sets the HTTP request method.
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Gets or sets the custom HTTP headers.
    /// </summary>
    [JsonPropertyName("headers")]
    public List<string> Headers { get; set; } = new();

    /// <summary>
    /// Gets or sets the idle timeout.
    /// </summary>
    [JsonPropertyName("idle_timeout")]
    public string? IdleTimeout { get; set; }

    /// <summary>
    /// Gets or sets the ping timeout.
    /// </summary>
    [JsonPropertyName("ping_timeout")]
    public string? PingTimeout { get; set; }
}