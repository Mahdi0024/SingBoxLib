using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

public sealed class SshOutbound : OutboundWithDialFields
{
    public SshOutbound()
    {
        Type = "ssh";
        Tag = "ssh-out";
    }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("user")]
    public string? User { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("private_key")]
    public string? PrivateKey { get; set; }

    [JsonProperty("private_key_path")]
    public string? PrivateKeyPath { get; set; }

    [JsonProperty("private_key_passphrase")]
    public string? PrivateKeyPassphrase { get; set; }

    [JsonProperty("host_key")]
    public List<string>? HostKey { get; set; }

    [JsonProperty("host_key_algorithms")]
    public List<string>? HostKeyAlgorithms { get; set; }

    [JsonProperty("client_version")]
    public string? ClientVersion { get; set; }
}