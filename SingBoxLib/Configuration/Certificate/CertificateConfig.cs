namespace SingBoxLib.Configuration.Certificate;

/// <summary>
/// Configuration for top-level certificates to trust.
/// </summary>
public sealed class CertificateConfig
{
    /// <summary>
    /// The default X509 trusted CA certificate list.
    /// One of: system, mozilla, chrome, none.
    /// </summary>
    [JsonPropertyName("store")]
    public string? Store { get; set; }

    /// <summary>
    /// The certificate line array to trust, in PEM format.
    /// </summary>
    [JsonPropertyName("certificate")]
    public List<string>? Certificate { get; set; }

    /// <summary>
    /// The paths to certificates to trust, in PEM format.
    /// </summary>
    [JsonPropertyName("certificate_path")]
    public List<string>? CertificatePath { get; set; }

    /// <summary>
    /// The directory path to search for certificates to trust, in PEM format.
    /// </summary>
    [JsonPropertyName("certificate_directory_path")]
    public List<string>? CertificateDirectoryPath { get; set; }
}
