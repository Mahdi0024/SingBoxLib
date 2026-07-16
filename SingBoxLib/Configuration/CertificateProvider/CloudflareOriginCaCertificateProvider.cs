using System.Collections.Generic;
using System.Text.Json.Serialization;
using SingBoxLib.Configuration.CertificateProvider.Abstract;

namespace SingBoxLib.Configuration.CertificateProvider;

/// <summary>
/// Cloudflare Origin CA certificate provider.
/// </summary>
public sealed class CloudflareOriginCaCertificateProvider : CertificateProviderConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CloudflareOriginCaCertificateProvider"/> class.
    /// </summary>
    public CloudflareOriginCaCertificateProvider()
    {
        Type = "cloudflare-origin-ca";
    }

    /// <summary>
    /// List of domain names or wildcard domain names to include in the certificate.
    /// </summary>
    [JsonPropertyName("domain")]
    public required List<string> Domain { get; set; }

    /// <summary>
    /// Root directory used to store the issued certificate, private key, and metadata.
    /// </summary>
    [JsonPropertyName("data_directory")]
    public string? DataDirectory { get; set; }

    /// <summary>
    /// Cloudflare API token used to create the certificate.
    /// </summary>
    [JsonPropertyName("api_token")]
    public string? ApiToken { get; set; }

    /// <summary>
    /// Cloudflare Origin CA Key.
    /// </summary>
    [JsonPropertyName("origin_ca_key")]
    public string? OriginCaKey { get; set; }

    /// <summary>
    /// The signature type to request from Cloudflare.
    /// </summary>
    [JsonPropertyName("request_type")]
    public string? RequestType { get; set; }

    /// <summary>
    /// The requested certificate validity in days.
    /// </summary>
    [JsonPropertyName("requested_validity")]
    public int? RequestedValidity { get; set; }

    /// <summary>
    /// HTTP Client for all provider HTTP requests.
    /// </summary>
    [JsonPropertyName("http_client")]
    public object? HttpClient { get; set; }
}