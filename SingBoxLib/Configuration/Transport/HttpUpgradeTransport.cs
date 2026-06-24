using System.Collections.Generic;
using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Transport;

/// <summary>
/// Represents configuration for HTTP Upgrade transport.
/// </summary>
public class HttpUpgradeTransport : TransportConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpUpgradeTransport"/> class.
    /// </summary>
    public HttpUpgradeTransport()
    {
        Type = "httpupgrade";
    }

    /// <summary>
    /// Gets or sets the HTTP host.
    /// </summary>
    [JsonPropertyName("host")]
    public string? Host { get; set; }

    /// <summary>
    /// Gets or sets the HTTP request path.
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Gets or sets request headers.
    /// </summary>
    [JsonPropertyName("headers")]
    public Dictionary<string, string>? Headers { get; set; }
}
