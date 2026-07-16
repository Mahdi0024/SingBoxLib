namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a Tailscale DNS server configuration.
/// </summary>
public sealed class TailscaleDnsServer : DnsServer
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TailscaleDnsServer"/> class.
    /// </summary>
    public TailscaleDnsServer()
    {
        Type = "tailscale";
    }

    /// <summary>
    /// The tag of the Tailscale endpoint.
    /// </summary>
    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    /// <summary>
    /// Indicates whether default DNS resolvers should be accepted for fallback queries.
    /// </summary>
    [JsonPropertyName("accept_default_resolvers")]
    public bool? AcceptDefaultResolvers { get; set; }

    /// <summary>
    /// When enabled, single-label queries are retried against each Tailscale search domain.
    /// </summary>
    [JsonPropertyName("accept_search_domain")]
    public bool? AcceptSearchDomain { get; set; }
}
