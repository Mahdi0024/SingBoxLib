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
    [JsonProperty("type")]
    public string? Type { get; set; }

    /// <summary>
    /// QUIC traffic obfuscator password.
    /// </summary>
    [JsonProperty("password")]
    public string? Password { get; set; }
}