using System.Text.Json.Serialization;
using SingBoxLib.Configuration.CertificateProvider.Abstract;

namespace SingBoxLib.Configuration.CertificateProvider;

/// <summary>
/// Tailscale certificate provider.
/// </summary>
public sealed class TailscaleCertificateProvider : CertificateProviderConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TailscaleCertificateProvider"/> class.
    /// </summary>
    public TailscaleCertificateProvider()
    {
        Type = "tailscale";
    }

    /// <summary>
    /// The tag of the Tailscale endpoint to reuse.
    /// </summary>
    [JsonPropertyName("endpoint")]
    public required string Endpoint { get; set; }
}