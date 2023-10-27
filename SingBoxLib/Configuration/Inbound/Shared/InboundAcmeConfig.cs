namespace SingBoxLib.Configuration.Inbound.Shared;

public class InboundAcmeConfig
{
    [JsonProperty("domain")]
    public List<string>? Domain { get; set; }

    [JsonProperty("data_directory")]
    public string? DataDirectory { get; set; }

    [JsonProperty("default_server_name")]
    public string? DefaultServerName { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("provider")]
    public string? Provider { get; set; }

    [JsonProperty("disable_http_challenge")]
    public bool? DisableHttpChallenge { get; set; }

    [JsonProperty("disable_tls_alpn_challenge")]
    public bool? DisableTlsAlpnChallenge { get; set; }

    [JsonProperty("alternative_http_port")]
    public int? AlternativeHttpPort { get; set; }

    [JsonProperty("alternative_tls_port")]
    public int? AlternativeTlsPort { get; set; }

    [JsonProperty("external_account")]
    public ExternalAccountConfig? ExternalAccount { get; set; }

    [JsonProperty("dns01_challenge")]
    public Dns01ChallengeConfig? Dns01Challenge { get; set; }
}
