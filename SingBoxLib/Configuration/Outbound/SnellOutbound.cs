using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Snell outbound configuration.
/// </summary>
public sealed class SnellOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SnellOutbound"/> class.
    /// </summary>
    public SnellOutbound()
    {
        Type = "snell";
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
    /// The Snell protocol version, one of 4, 6.
    /// </summary>
    [JsonPropertyName("version")]
    public required int Version { get; set; }

    /// <summary>
    /// The pre-shared key.
    /// </summary>
    [JsonPropertyName("psk")]
    public required string Psk { get; set; }

    /// <summary>
    /// The user key, used to authenticate against a multi-user server.
    /// </summary>
    [JsonPropertyName("userkey")]
    public string? UserKey { get; set; }

    /// <summary>
    /// Enable connection reuse.
    /// </summary>
    [JsonPropertyName("reuse")]
    public bool? Reuse { get; set; }

    /// <summary>
    /// Enabled network (tcp or udp).
    /// </summary>
    [JsonPropertyName("network")]
    public string? Network { get; set; }

    /// <summary>
    /// HTTP obfuscation mode, one of none, http. Version 4 only.
    /// </summary>
    [JsonPropertyName("obfs_mode")]
    public string? ObfsMode { get; set; }

    /// <summary>
    /// The HTTP Host header sent when obfs_mode is http. Version 4 only.
    /// </summary>
    [JsonPropertyName("obfs_host")]
    public string? ObfsHost { get; set; }

    /// <summary>
    /// Traffic shaping mode, one of default, unshaped, unsafe-raw. Version 6 only.
    /// </summary>
    [JsonPropertyName("mode")]
    public string? Mode { get; set; }
}