namespace SingBoxLib.Configuration.Shared;

/// <summary>
/// Represents Hysteria 2 obfuscation configuration.
/// </summary>
public sealed class Hysteria2Obfs
{
    /// <summary>
    /// QUIC traffic obfuscator type, only available with salamander.
    /// Disabled if empty.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// QUIC traffic obfuscator password.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }
}