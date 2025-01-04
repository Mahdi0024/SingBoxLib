using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a Ssh outbound.
/// </summary>
public sealed class SshOutbound : OutboundWithDialFields
{
    public SshOutbound(string? tag = null)
    {
        Type = "ssh";
        Tag = tag ?? "ssh-out";
    }

    /// <summary>
    /// The server address.
    /// </summary>
    [JsonProperty("server")]
    public required string Server { get; set; }

    /// <summary>
    /// The server port.
    /// 22 will be used if empty.
    /// </summary>
    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    /// <summary>
    /// SSH user, root will be used if empty.
    /// </summary>
    [JsonProperty("user")]
    public string? User { get; set; }

    /// <summary>
    /// Password.
    /// </summary>
    [JsonProperty("password")]
    public string? Password { get; set; }

    /// <summary>
    /// Private key.
    /// </summary>
    [JsonProperty("private_key")]
    public string? PrivateKey { get; set; }

    /// <summary>
    /// Private key path.
    /// </summary>
    [JsonProperty("private_key_path")]
    public string? PrivateKeyPath { get; set; }

    /// <summary>
    /// Private key passphrase.
    /// </summary>
    [JsonProperty("private_key_passphrase")]
    public string? PrivateKeyPassphrase { get; set; }

    /// <summary>
    /// Host key. Accept any if empty.
    /// </summary>
    [JsonProperty("host_key")]
    public List<string>? HostKey { get; set; }

    /// <summary>
    /// Host key algorithms.
    /// </summary>
    [JsonProperty("host_key_algorithms")]
    public List<string>? HostKeyAlgorithms { get; set; }

    /// <summary>
    /// Client version. Random version will be used if empty.
    /// </summary>
    [JsonProperty("client_version")]
    public string? ClientVersion { get; set; }
}