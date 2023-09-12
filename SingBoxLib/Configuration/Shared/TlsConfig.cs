namespace SingBoxLib.Configuration.Shared;

public sealed class TlsConfig
{
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    [JsonProperty("disable_sni")]
    public bool? DisableSni { get; set; }

    [JsonProperty("server_name")]
    public string? ServerName { get; set; }

    [JsonProperty("insecure")]
    public bool? Insecure { get; set; }

    [JsonProperty("alpn")]
    public List<string>? Alpn { get; set; }

    [JsonProperty("min_version")]
    public string? MinVersion { get; set; }

    [JsonProperty("max_version")]
    public string? MaxVersion { get; set; }

    [JsonProperty("cipher_suits")]
    public List<string>? CipherSuites { get; set; }

    [JsonProperty("certificate")]
    public string? Certificate { get; set; }

    [JsonProperty("certificate_path")]
    public string? CertificatePath { get; set; }

    [JsonProperty("ech")]
    public EchConfig? Ech { get; set; }

    [JsonProperty("utls")]
    public UtlsConfig? UTls { get; set; }

    [JsonProperty("reality")]
    public RealityConfig? Reality { get; set; }
}

public static class TlsVersions
{
    public const string V1_0 = "1.0";
    public const string V1_1 = "1.1";
    public const string V1_2 = "1.2";
    public const string V1_3 = "1.3";
}

public static class TlsCipherSuites
{
    public const string TlsRsaWithAes128CbcSha = "TLS_RSA_WITH_AES_128_CBC_SHA";
    public const string TlsRsaWithAes256CbcSha = "TLS_RSA_WITH_AES_256_CBC_SHA";
    public const string TlsRsaWithAes128GcmSha256 = "TLS_RSA_WITH_AES_128_GCM_SHA256";
    public const string TlsRsaWithAes256GcmSha384 = "TLS_RSA_WITH_AES_256_GCM_SHA384";
    public const string TlsAes128GcmSha256 = "TLS_AES_128_GCM_SHA256";
    public const string TlsAes256GcmSha384 = "TLS_AES_256_GCM_SHA384";
    public const string TlsChacha20Poly1305Sha256 = "TLS_CHACHA20_POLY1305_SHA256";
    public const string TlsEcdheEcdsaWithAes128CbcSha = "TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA";
    public const string TlsEcdheEcdsaWithAes256CbcSha = "TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA";
    public const string TlsEcdheRsaWithAes128CbcSha = "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA";
    public const string TlsEcdheRsaWithAes256CbcSha = "TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA";
    public const string TlsEcdheEcdsaWithAes128GcmSha256 = "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256";
    public const string TlsEcdheEcdsaWithAes256GcmSha384 = "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384";
    public const string TlsEcdheRsaWithAes128GcmSha256 = "TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256";
    public const string TlsEcdheRsaWithAes256GcmSha384 = "TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384";
    public const string TlsEcdheEcdsaWithChacha20Poly1305Sha256 = "TLS_ECDHE_ECDSA_WITH_CHACHA20_POLY1305_SHA256";
    public const string TlsEcdheRsaWithChacha20Poly1305Sha256 = "TLS_ECDHE_RSA_WITH_CHACHA20_POLY1305_SHA256";
}