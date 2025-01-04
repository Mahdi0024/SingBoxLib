using SingBoxLib.Configuration.Inbound.Shared;

namespace SingboxLib.Configuration.Inbound.Shared;

/// <summary>
/// Represents configuration for inbound TLS settings.
/// </summary>
public class InboundTlsConfig
{
    /// <summary>
    /// Indicates whether TLS is enabled.
    /// </summary>
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// The server name used to verify the hostname on the returned certificates unless insecure is given.
    /// It is also included in the client's handshake to support virtual hosting unless it is an IP address.
    /// </summary>
    [JsonProperty("server_name")]
    public string? ServerName { get; set; }

    /// <summary>
    /// List of supported application level protocols, in order of preference.
    /// If both peers support ALPN, the selected protocol will be one from this list,
    /// and the connection will fail if there is no mutually supported protocol.
    /// </summary>
    [JsonProperty("alpn")]
    public List<string>? Alpn { get; set; }

    /// <summary>
    /// The minimum TLS version that is acceptable.
    /// By default, TLS 1.2 is currently used as the minimum when acting as a client,
    /// and TLS 1.0 when acting as a server.
    /// </summary>
    [JsonProperty("min_version")]
    public string? MinVersion { get; set; }

    /// <summary>
    /// The maximum TLS version that is acceptable.
    /// By default, the maximum version is currently TLS 1.3.
    /// </summary>
    [JsonProperty("max_version")]
    public string? MaxVersion { get; set; }

    /// <summary>
    /// A list of enabled TLS 1.0–1.2 cipher suites. The order of the list is ignored.
    /// Note that TLS 1.3 cipher suites are not configurable.
    /// If empty, a safe default list is used. The default cipher suites might change over time.
    /// </summary>
    [JsonProperty("cipher_suites")]
    public List<string>? CipherSuites { get; set; }

    /// <summary>
    /// The server certificate in PEM format.
    /// </summary>
    [JsonProperty("certificate")]
    public List<string>? Certificate { get; set; }

    /// <summary>
    /// The path to the server certificate, which will be automatically reloaded if modified.
    /// </summary>
    [JsonProperty("certificate_path")]
    public string? CertificatePath { get; set; }

    /// <summary>
    /// The server private key in PEM format.
    /// </summary>
    [JsonProperty("key")]
    public List<string>? Key { get; set; }

    /// <summary>
    /// The path to the server private key, which will be automatically reloaded if modified.
    /// </summary>
    [JsonProperty("key_path")]
    public string? KeyPath { get; set; }

    /// <summary>
    /// Configuration for ACME (Automatic Certificate Management Environment).
    /// </summary>
    [JsonProperty("acme")]
    public InboundAcmeConfig? Acme { get; set; }

    /// <summary>
    /// Configuration for ECH (Encrypted Client Hello).
    /// </summary>
    [JsonProperty("ech")]
    public InboundEchConfig? Ech { get; set; }

    /// <summary>
    /// Configuration for Reality, a TLS extension.
    /// </summary>
    [JsonProperty("reality")]
    public InboundRealityConfig? Reality { get; set; }
}