using System.Collections.Generic;
using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Inbound.Shared;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// AnyTLS inbound configuration.
/// </summary>
public sealed class AnyTlsInbound : InboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AnyTlsInbound"/> class.
    /// </summary>
    public AnyTlsInbound()
    {
        Type = "anytls";
    }

    /// <summary>
    /// AnyTLS users.
    /// </summary>
    [JsonPropertyName("users")]
    public required List<AnyTlsUser> Users { get; set; }

    /// <summary>
    /// AnyTLS padding scheme line array.
    /// </summary>
    [JsonPropertyName("padding_scheme")]
    public List<string>? PaddingScheme { get; set; }

    /// <summary>
    /// TLS configuration.
    /// </summary>
    [JsonPropertyName("tls")]
    public InboundTlsConfig? Tls { get; set; }
}

/// <summary>
/// Represents a user for AnyTLS inbound.
/// </summary>
public sealed class AnyTlsUser
{
    /// <summary>
    /// The name of the user.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The password of the user.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }
}