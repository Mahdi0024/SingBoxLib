namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a Resolved DNS server configuration.
/// </summary>
public sealed class ResolvedDnsServer : DnsServer
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ResolvedDnsServer"/> class.
    /// </summary>
    public ResolvedDnsServer()
    {
        Type = "resolved";
    }

    /// <summary>
    /// The tag of the Resolved service.
    /// </summary>
    [JsonPropertyName("service")]
    public string? Service { get; set; }

    /// <summary>
    /// Indicates whether the default DNS resolvers should be accepted for fallback queries.
    /// </summary>
    [JsonPropertyName("accept_default_resolvers")]
    public bool? AcceptDefaultResolvers { get; set; }
}
