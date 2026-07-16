namespace SingBoxLib.Configuration.Outbound.Shared;

/// <summary>
/// Represents TLS outbound configuration.
/// </summary>
public sealed class OutboundTlsConfig
{
    /// <summary>
    /// Gets or sets whether TLS is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets whether to disable Server Name Indication (SNI).
    /// </summary>
    [JsonPropertyName("disable_sni")]
    public bool? DisableSni { get; set; }

    /// <summary>
    /// Gets or sets the server name.
    /// </summary>
    [JsonPropertyName("server_name")]
    public string? ServerName { get; set; }

    /// <summary>
    /// Gets or sets whether to skip TLS certificate verification.
    /// </summary>
    [JsonPropertyName("insecure")]
    public bool? Insecure { get; set; }

    /// <summary>
    /// Gets or sets the list of ALPN (Application-Layer Protocol Negotiation) protocols.
    /// </summary>
    [JsonPropertyName("alpn")]
    public List<string>? Alpn { get; set; }

    /// <summary>
    /// Gets or sets the minimum TLS version allowed.
    /// </summary>
    [JsonPropertyName("min_version")]
    public string? MinVersion { get; set; }

    /// <summary>
    /// Gets or sets the maximum TLS version allowed.
    /// </summary>
    [JsonPropertyName("max_version")]
    public string? MaxVersion { get; set; }

    /// <summary>
    /// Gets or sets the list of TLS cipher suites.
    /// </summary>
    [JsonPropertyName("cipher_suites")]
    public List<string>? CipherSuites { get; set; }

    /// <summary>
    /// Gets or sets the PEM-encoded certificate.
    /// </summary>
    [JsonPropertyName("certificate")]
    public string? Certificate { get; set; }

    /// <summary>
    /// Gets or sets the path to the TLS certificate file.
    /// </summary>
    [JsonPropertyName("certificate_path")]
    public string? CertificatePath { get; set; }

    /// <summary>
    /// Gets or sets the Encrypted Client Hello (ECH) configuration.
    /// </summary>
    [JsonPropertyName("ech")]
    public OutboundEchConfig? Ech { get; set; }

    /// <summary>
    /// Gets or sets the uTLS configuration.
    /// </summary>
    [JsonPropertyName("utls")]
    public UtlsConfig? UTls { get; set; }

    /// <summary>
    /// Gets or sets the Reality configuration.
    /// </summary>
    [JsonPropertyName("reality")]
    public OutboundRealityConfig? Reality { get; set; }

    /// <summary>
    /// Since 1.14.0. TLS engine to use (e.g. go, apple, windows).
    /// </summary>
    [JsonPropertyName("engine")]
    public string? Engine { get; set; }

    /// <summary>
    /// Since 1.13.0. Supported key exchange mechanisms.
    /// </summary>
    [JsonPropertyName("curve_preferences")]
    public List<string>? CurvePreferences { get; set; }

    /// <summary>
    /// Since 1.13.0. SHA-256 hashes of server certificate public keys.
    /// </summary>
    [JsonPropertyName("certificate_public_key_sha256")]
    public List<string>? CertificatePublicKeySha256 { get; set; }

    /// <summary>
    /// Since 1.13.0. Client certificate.
    /// </summary>
    [JsonPropertyName("client_certificate")]
    public List<string>? ClientCertificate { get; set; }

    /// <summary>
    /// Since 1.13.0. Path to client certificate.
    /// </summary>
    [JsonPropertyName("client_certificate_path")]
    public string? ClientCertificatePath { get; set; }

    /// <summary>
    /// Since 1.13.0. Client private key.
    /// </summary>
    [JsonPropertyName("client_key")]
    public List<string>? ClientKey { get; set; }

    /// <summary>
    /// Since 1.13.0. Path to client private key.
    /// </summary>
    [JsonPropertyName("client_key_path")]
    public string? ClientKeyPath { get; set; }

    /// <summary>
    /// Since 1.12.0. Fragment TLS handshakes to bypass firewalls.
    /// </summary>
    [JsonPropertyName("fragment")]
    public bool? Fragment { get; set; }

    /// <summary>
    /// Since 1.12.0. Fallback value when TLS segmentation cannot automatically determine wait time.
    /// </summary>
    [JsonPropertyName("fragment_fallback_delay")]
    public string? FragmentFallbackDelay { get; set; }

    /// <summary>
    /// Since 1.12.0. Fragment TLS handshake into multiple TLS records.
    /// </summary>
    [JsonPropertyName("record_fragment")]
    public bool? RecordFragment { get; set; }

    /// <summary>
    /// Since 1.14.0. SNI for forged segment.
    /// </summary>
    [JsonPropertyName("spoof")]
    public string? Spoof { get; set; }

    /// <summary>
    /// Since 1.14.0. How forged segment is rejected by real server.
    /// </summary>
    [JsonPropertyName("spoof_method")]
    public string? SpoofMethod { get; set; }

    /// <summary>
    /// Since 1.13.0. Enable kernel TLS transmit support.
    /// </summary>
    [JsonPropertyName("kernel_tx")]
    public bool? KernelTx { get; set; }

    /// <summary>
    /// Since 1.13.0. Enable kernel TLS receive support.
    /// </summary>
    [JsonPropertyName("kernel_rx")]
    public bool? KernelRx { get; set; }

    /// <summary>
    /// Since 1.14.0. TLS handshake timeout.
    /// </summary>
    [JsonPropertyName("handshake_timeout")]
    public string? HandshakeTimeout { get; set; }
}

/// <summary>
/// Constants representing TLS version strings.
/// </summary>
public static class TlsVersions
{
    /// <summary>
    /// TLS version 1.0.
    /// </summary>
    public const string V1_0 = "1.0";

    /// <summary>
    /// TLS version 1.1.
    /// </summary>
    public const string V1_1 = "1.1";

    /// <summary>
    /// TLS version 1.2.
    /// </summary>
    public const string V1_2 = "1.2";

    /// <summary>
    /// TLS version 1.3.
    /// </summary>
    public const string V1_3 = "1.3";
}

/// <summary>
/// Constants representing TLS cipher suites.
/// </summary>
public static class TlsCipherSuites
{
    /// <summary>
    /// TLS cipher suite: TLS_RSA_WITH_AES_128_CBC_SHA.
    /// </summary>
    public const string TlsRsaWithAes128CbcSha = "TLS_RSA_WITH_AES_128_CBC_SHA";

    /// <summary>
    /// TLS cipher suite: TLS_RSA_WITH_AES_256_CBC_SHA.
    /// </summary>
    public const string TlsRsaWithAes256CbcSha = "TLS_RSA_WITH_AES_256_CBC_SHA";

    /// <summary>
    /// TLS cipher suite: TLS_RSA_WITH_AES_128_GCM_SHA256.
    /// </summary>
    public const string TlsRsaWithAes128GcmSha256 = "TLS_RSA_WITH_AES_128_GCM_SHA256";

    /// <summary>
    /// TLS cipher suite: TLS_RSA_WITH_AES_256_GCM_SHA384.
    /// </summary>
    public const string TlsRsaWithAes256GcmSha384 = "TLS_RSA_WITH_AES_256_GCM_SHA384";

    /// <summary>
    /// TLS cipher suite: TLS_AES_128_GCM_SHA256.
    /// </summary>
    public const string TlsAes128GcmSha256 = "TLS_AES_128_GCM_SHA256";

    /// <summary>
    /// TLS cipher suite: TLS_AES_256_GCM_SHA384.
    /// </summary>
    public const string TlsAes256GcmSha384 = "TLS_AES_256_GCM_SHA384";

    /// <summary>
    /// TLS cipher suite: TLS_CHACHA20_POLY1305_SHA256.
    /// </summary>
    public const string TlsChacha20Poly1305Sha256 = "TLS_CHACHA20_POLY1305_SHA256";

    /// <summary>
    /// TLS cipher suite: TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA.
    /// </summary>
    public const string TlsEcdheEcdsaWithAes128CbcSha = "TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA";

    /// <summary>
    /// TLS cipher suite: TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA.
    /// </summary>
    public const string TlsEcdheEcdsaWithAes256CbcSha = "TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA";

    /// <summary>
    /// TLS cipher suite: TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA.
    /// </summary>
    public const string TlsEcdheRsaWithAes128CbcSha = "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA";

    /// <summary>
    /// TLS cipher suite: TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA.
    /// </summary>
    public const string TlsEcdheRsaWithAes256CbcSha = "TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA";

    /// <summary>
    /// TLS cipher suite: TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256.
    /// </summary>
    public const string TlsEcdheEcdsaWithAes128GcmSha256 = "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256";

    /// <summary>
    /// TLS cipher suite: TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384.
    /// </summary>
    public const string TlsEcdheEcdsaWithAes256GcmSha384 = "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384";

    /// <summary>
    /// TLS cipher suite: TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256.
    /// </summary>
    public const string TlsEcdheRsaWithAes128GcmSha256 = "TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256";

    /// <summary>
    /// TLS cipher suite: TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384.
    /// </summary>
    public const string TlsEcdheRsaWithAes256GcmSha384 = "TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384";

    /// <summary>
    /// TLS cipher suite: TLS_ECDHE_ECDSA_WITH_CHACHA20_POLY1305_SHA256.
    /// </summary>
    public const string TlsEcdheEcdsaWithChacha20Poly1305Sha256 = "TLS_ECDHE_ECDSA_WITH_CHACHA20_POLY1305_SHA256";

    /// <summary>
    /// TLS cipher suite: TLS_ECDHE_RSA_WITH_CHACHA20_POLY1305_SHA256.
    /// </summary>
    public const string TlsEcdheRsaWithChacha20Poly1305Sha256 = "TLS_ECDHE_RSA_WITH_CHACHA20_POLY1305_SHA256";
}