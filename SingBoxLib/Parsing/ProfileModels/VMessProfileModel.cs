using System.Text.Json.Serialization;

namespace SingBoxLib.Parsing.ProfileModels;

/// <summary>
/// Represents a VMess profile model parsed from configuration URLs.
/// </summary>
public sealed class VMessProfileModel
{
    /// <summary>
    /// Version.
    /// </summary>
    [JsonPropertyName("v")]
    public string? Version { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    [JsonPropertyName("ps")]
    public string? Name { get; set; }

    /// <summary>
    /// Address.
    /// </summary>
    [JsonPropertyName("add")]
    public string? Address { get; set; }

    /// <summary>
    /// Port.
    /// </summary>
    [JsonPropertyName("port")]
    public ushort? Port { get; set; }

    /// <summary>
    /// User ID / UUID.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// AlterId.
    /// </summary>
    [JsonPropertyName("aid")]
    public string? AlterId { get; set; }

    /// <summary>
    /// Encryption.
    /// </summary>
    [JsonPropertyName("scy")]
    public string? Encryption { get; set; }

    /// <summary>
    /// Network type.
    /// </summary>
    [JsonPropertyName("net")]
    public string? Network { get; set; }

    /// <summary>
    /// Type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Host header.
    /// </summary>
    [JsonPropertyName("host")]
    public string? Host { get; set; }

    /// <summary>
    /// ALPN.
    /// </summary>
    [JsonPropertyName("alpn")]
    public string? Alpn { get; set; }

    /// <summary>
    /// Path.
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Security type.
    /// </summary>
    [JsonPropertyName("tls")]
    public string? Security { get; set; }

    /// <summary>
    /// SNI server name.
    /// </summary>
    [JsonPropertyName("sni")]
    public string? Sni { get; set; }

    /// <summary>
    /// Fingerprint.
    /// </summary>
    [JsonPropertyName("fp")]
    public string? Fingerprint { get; set; }

    /// <summary>
    /// Maps this VMess profile model to a standard <see cref="ProfileItem"/>.
    /// </summary>
    /// <returns>A mapped <see cref="ProfileItem"/>.</returns>
    public ProfileItem MapToProfileItem()
    {
        return new ProfileItem
        {
            Type = ProfileType.VMess,
            Name = Name,
            Address = Address,
            Port = Port,
            Id = Id,
            AlterId = int.Parse(AlterId!),
            Encryption = Encryption,
            Network = Network,
            RequestHost = Host,
            Alpn = Alpn,
            Path = Path,
            Security = Security,
            Sni = Sni,
            Fingerprint = Fingerprint,
        };
    }
}
