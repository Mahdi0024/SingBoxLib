using System.Collections.Generic;
using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Inbound.Abstract;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Snell inbound configuration.
/// </summary>
public sealed class SnellInbound : InboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SnellInbound"/> class.
    /// </summary>
    public SnellInbound()
    {
        Type = "snell";
    }

    /// <summary>
    /// The Snell protocol version, one of 5, 6.
    /// </summary>
    [JsonPropertyName("version")]
    public required int Version { get; set; }

    /// <summary>
    /// The pre-shared key.
    /// </summary>
    [JsonPropertyName("psk")]
    public required string Psk { get; set; }

    /// <summary>
    /// Snell users.
    /// </summary>
    [JsonPropertyName("users")]
    public List<SnellUser>? Users { get; set; }

    /// <summary>
    /// HTTP obfuscation mode, one of none, http. Version 5 only.
    /// </summary>
    [JsonPropertyName("obfs_mode")]
    public string? ObfsMode { get; set; }

    /// <summary>
    /// Traffic shaping mode, one of default, unshaped, unsafe-raw. Version 6 only.
    /// </summary>
    [JsonPropertyName("mode")]
    public string? Mode { get; set; }
}

/// <summary>
/// Represents a user for multi-user Snell inbound.
/// </summary>
public sealed class SnellUser
{
    /// <summary>
    /// The name of the user.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The user key.
    /// </summary>
    [JsonPropertyName("userkey")]
    public string? UserKey { get; set; }
}