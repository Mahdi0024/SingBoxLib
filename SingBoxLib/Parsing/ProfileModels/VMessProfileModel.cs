namespace SingBoxLib.Parsing.ProfileModels;

public sealed class VMessProfileModel
{
    [JsonPropertyName("v")]
    public string? Version { get; set; }

    [JsonPropertyName("ps")]
    public string? Name { get; set; }

    [JsonPropertyName("add")]
    public string? Address { get; set; }

    [JsonPropertyName("port")]
    public ushort? Port { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("aid")]
    public string? AlterId { get; set; }

    [JsonPropertyName("scy")]
    public string? Encryption { get; set; }

    [JsonPropertyName("net")]
    public string? Network { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("host")]
    public string? Host { get; set; }

    [JsonPropertyName("alpn")]
    public string? Alpn { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("tls")]
    public string? Security { get; set; }

    [JsonPropertyName("sni")]
    public string? Sni { get; set; }

    [JsonPropertyName("fp")]
    public string? Fingerprint { get; set; }

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