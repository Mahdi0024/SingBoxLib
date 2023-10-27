using SingBoxLib.Configuration.Inbound.Shared;

namespace SingboxLib.Configuration.Inbound.Shared;

public class InboundTlsConfig
{
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    [JsonProperty("server_name")]
    public string? ServerName { get; set; }

    [JsonProperty("alpn")]
    public List<string>? Alpn { get; set; }

    [JsonProperty("min_version")]
    public string? MinVersion { get; set; }

    [JsonProperty("max_version")]
    public string? MaxVersion { get; set; }

    [JsonProperty("cipher_suites")]
    public List<string>? CipherSuites { get; set; }

    [JsonProperty("certificate")]
    public List<string>? Certificate { get; set; }

    [JsonProperty("certificate_path")]
    public string? CertificatePath { get; set; }

    [JsonProperty("key")]
    public List<string>? Key { get; set; }

    [JsonProperty("key_path")]
    public string? KeyPath { get; set; }

    [JsonProperty("acme")]
    public InboundAcmeConfig? Acme { get; set; }

    [JsonProperty("ech")]
    public InboundEchConfig? Ech { get; set; }

    [JsonProperty("reality")]
    public InboundRealityConfig? Reality { get; set; }
}