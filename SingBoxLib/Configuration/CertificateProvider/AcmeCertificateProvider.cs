using System.Collections.Generic;
using System.Text.Json.Serialization;
using SingBoxLib.Configuration.CertificateProvider.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.CertificateProvider;

/// <summary>
/// ACME certificate provider.
/// </summary>
public sealed class AcmeCertificateProvider : CertificateProviderConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AcmeCertificateProvider"/> class.
    /// </summary>
    public AcmeCertificateProvider()
    {
        Type = "acme";
    }

    /// <summary>
    /// List of domains.
    /// </summary>
    [JsonPropertyName("domain")]
    public required List<string> Domain { get; set; }

    /// <summary>
    /// The directory to store ACME data.
    /// </summary>
    [JsonPropertyName("data_directory")]
    public string? DataDirectory { get; set; }

    /// <summary>
    /// Server name to use when choosing a certificate if ServerName field is empty.
    /// </summary>
    [JsonPropertyName("default_server_name")]
    public string? DefaultServerName { get; set; }

    /// <summary>
    /// The email address to use when creating or selecting an existing ACME server account.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The ACME CA provider to use.
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    /// <summary>
    /// The PEM-encoded private key of an existing ACME account.
    /// </summary>
    [JsonPropertyName("account_key")]
    public string? AccountKey { get; set; }

    /// <summary>
    /// Disable all HTTP challenges.
    /// </summary>
    [JsonPropertyName("disable_http_challenge")]
    public bool? DisableHttpChallenge { get; set; }

    /// <summary>
    /// Disable all TLS-ALPN challenges.
    /// </summary>
    [JsonPropertyName("disable_tls_alpn_challenge")]
    public bool? DisableTlsAlpnChallenge { get; set; }

    /// <summary>
    /// Alternate port to use for the ACME HTTP challenge.
    /// </summary>
    [JsonPropertyName("alternative_http_port")]
    public int? AlternativeHttpPort { get; set; }

    /// <summary>
    /// Alternate port to use for the ACME TLS-ALPN challenge.
    /// </summary>
    [JsonPropertyName("alternative_tls_port")]
    public int? AlternativeTlsPort { get; set; }

    /// <summary>
    /// External account binding details.
    /// </summary>
    [JsonPropertyName("external_account")]
    public AcmeExternalAccount? ExternalAccount { get; set; }

    /// <summary>
    /// ACME DNS01 challenge settings.
    /// </summary>
    [JsonPropertyName("dns01_challenge")]
    public Dns01ChallengeConfig? Dns01Challenge { get; set; }

    /// <summary>
    /// Private key type to generate for new certificates.
    /// </summary>
    [JsonPropertyName("key_type")]
    public string? KeyType { get; set; }

    /// <summary>
    /// The ACME profile to use for certificate issuance.
    /// </summary>
    [JsonPropertyName("profile")]
    public string? Profile { get; set; }

    /// <summary>
    /// HTTP Client for all provider HTTP requests.
    /// </summary>
    [JsonPropertyName("http_client")]
    public object? HttpClient { get; set; }
}

/// <summary>
/// EAB (External Account Binding) details.
/// </summary>
public sealed class AcmeExternalAccount
{
    /// <summary>
    /// The key identifier.
    /// </summary>
    [JsonPropertyName("key_id")]
    public string? KeyId { get; set; }

    /// <summary>
    /// The MAC key.
    /// </summary>
    [JsonPropertyName("mac_key")]
    public string? MacKey { get; set; }
}