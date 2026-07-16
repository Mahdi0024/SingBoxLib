using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Outbound.Shared;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// AnyTLS outbound configuration.
/// </summary>
public sealed class AnyTlsOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AnyTlsOutbound"/> class.
    /// </summary>
    public AnyTlsOutbound()
    {
        Type = "anytls";
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
    /// The AnyTLS password.
    /// </summary>
    [JsonPropertyName("password")]
    public required string Password { get; set; }

    /// <summary>
    /// Interval checking for idle sessions.
    /// </summary>
    [JsonPropertyName("idle_session_check_interval")]
    public string? IdleSessionCheckInterval { get; set; }

    /// <summary>
    /// In the check, close sessions that have been idle for longer than this.
    /// </summary>
    [JsonPropertyName("idle_session_timeout")]
    public string? IdleSessionTimeout { get; set; }

    /// <summary>
    /// In the check, at least the first n idle sessions are kept open.
    /// </summary>
    [JsonPropertyName("min_idle_session")]
    public int? MinIdleSession { get; set; }

    /// <summary>
    /// TLS configuration.
    /// </summary>
    [JsonPropertyName("tls")]
    public required OutboundTlsConfig Tls { get; set; }
}