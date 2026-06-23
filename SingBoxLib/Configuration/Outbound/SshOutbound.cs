namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a Ssh outbound.
/// </summary>
public sealed class SshOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SshOutbound"/> class.
    /// </summary>
    /// <param name="tag">The optional outbound tag.</param>
    public SshOutbound(string? tag = null)
    {
        Type = "ssh";
        Tag = tag ?? "ssh-out";
    }

    /// <summary>
    /// The server address.
    /// </summary>
    [JsonPropertyName("server")]
    public required string Server { get; set; }

    /// <summary>
    /// The server port.
    /// 22 will be used if empty.
    /// </summary>
    [JsonPropertyName("server_port")]
    public int? ServerPort { get; set; }

    /// <summary>
    /// SSH user, root will be used if empty.
    /// </summary>
    [JsonPropertyName("user")]
    public string? User { get; set; }

    /// <summary>
    /// Password.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// Private key.
    /// </summary>
    [JsonPropertyName("private_key")]
    public string? PrivateKey { get; set; }

    /// <summary>
    /// Private key path.
    /// </summary>
    [JsonPropertyName("private_key_path")]
    public string? PrivateKeyPath { get; set; }

    /// <summary>
    /// Private key passphrase.
    /// </summary>
    [JsonPropertyName("private_key_passphrase")]
    public string? PrivateKeyPassphrase { get; set; }

    /// <summary>
    /// Host key. Accept any if empty.
    /// </summary>
    [JsonPropertyName("host_key")]
    public List<string>? HostKey { get; set; }

    /// <summary>
    /// Host key algorithms.
    /// </summary>
    [JsonPropertyName("host_key_algorithms")]
    public List<string>? HostKeyAlgorithms { get; set; }

    /// <summary>
    /// Client version. Random version will be used if empty.
    /// </summary>
    [JsonPropertyName("client_version")]
    public string? ClientVersion { get; set; }
}