using SingboxLib.Configuration.Outbound.Shared;
using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a HTTP outbound.
/// </summary>
public sealed class HttpOutbound : OutboundWithDialFields
{
    public HttpOutbound(string? tag = null)
    {
        Type = "http";
        Tag = tag ?? "http-out";
    }

    /// <summary>
    /// The server address.
    /// </summary>
    [JsonProperty("server")]
    public required string Server { get; set; }

    /// <summary>
    /// The server port.
    /// </summary>
    [JsonProperty("server_port")]
    public required int ServerPort { get; set; }

    /// <summary>
    /// Basic authorization username.
    /// </summary>
    [JsonProperty("username")]
    public string? Username { get; set; }

    /// <summary>
    /// Basic authorization password.
    /// </summary>
    [JsonProperty("password")]
    public string? Password { get; set; }

    /// <summary>
    /// Path of HTTP request.
    /// </summary>
    [JsonProperty("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Extra headers of HTTP request.
    /// </summary>
    [JsonProperty("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#outbound">TLS</see>.
    /// </summary>
    [JsonProperty("tls")]
    public OutboundTlsConfig? Tls { get; set; }
}