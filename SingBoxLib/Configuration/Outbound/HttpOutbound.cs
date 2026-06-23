namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a HTTP outbound.
/// </summary>
public sealed class HttpOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpOutbound"/> class.
    /// </summary>
    /// <param name="tag">The optional outbound tag.</param>
    public HttpOutbound(string? tag = null)
    {
        Type = "http";
        Tag = tag ?? "http-out";
    }

    /// <summary>
    /// The server address.
    /// </summary>
    [JsonPropertyName("server")]
    public required string Server { get; set; }

    /// <summary>
    /// The server port.
    /// </summary>
    [JsonPropertyName("server_port")]
    public required int ServerPort { get; set; }

    /// <summary>
    /// Basic authorization username.
    /// </summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>
    /// Basic authorization password.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// Path of HTTP request.
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Extra headers of HTTP request.
    /// </summary>
    [JsonPropertyName("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#outbound">TLS</see>.
    /// </summary>
    [JsonPropertyName("tls")]
    public OutboundTlsConfig? Tls { get; set; }
}