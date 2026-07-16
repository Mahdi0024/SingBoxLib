using System.Text.Json.Serialization;
using SingBoxLib.Configuration.CertificateProvider;

namespace SingBoxLib.Configuration.CertificateProvider.Abstract;

/// <summary>
/// Represents the base class for certificate provider configurations.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(AcmeCertificateProvider), "acme")]
[JsonDerivedType(typeof(TailscaleCertificateProvider), "tailscale")]
[JsonDerivedType(typeof(CloudflareOriginCaCertificateProvider), "cloudflare-origin-ca")]
public abstract class CertificateProviderConfig
{
    /// <summary>
    /// Gets or sets the certificate provider type.
    /// </summary>
    [JsonIgnore]
    public string? Type { get; internal set; }

    /// <summary>
    /// The tag of the certificate provider.
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }
}