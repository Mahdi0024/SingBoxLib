namespace SingBoxLib.Parsing.ProfileModels;

internal sealed class VMessProfileModel
{
    [JsonProperty("v")]
    public string? Version { get; set; }

    [JsonProperty("ps")]
    public string? Name { get; set; }

    [JsonProperty("add")]
    public string? Address { get; set; }

    [JsonProperty("port")]
    public ushort? Port { get; set; }

    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("aid")]
    public string? AlterId { get; set; }

    [JsonProperty("scy")]
    public string? Encryption { get; set; }

    [JsonProperty("net")]
    public string? Network { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("host")]
    public string? Host { get; set; }

    [JsonProperty("alpn")]
    public string? Alpn { get; set; }

    [JsonProperty("path")]
    public string? Path { get; set; }

    [JsonProperty("tls")]
    public string? Security { get; set; }

    [JsonProperty("sni")]
    public string? Sni { get; set; }

    [JsonProperty("fp")]
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