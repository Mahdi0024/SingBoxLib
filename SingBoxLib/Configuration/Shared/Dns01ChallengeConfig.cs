using System.Text.Json.Serialization;

namespace SingBoxLib.Configuration.Shared;

/// <summary>
/// Represents DNS01 challenge settings for ACME certificate provider.
/// </summary>
public sealed class Dns01ChallengeConfig
{
    /// <summary>
    /// TTL of the temporary TXT record.
    /// </summary>
    [JsonPropertyName("ttl")]
    public string? Ttl { get; set; }

    /// <summary>
    /// How long to wait after creating challenge record before starting checks.
    /// </summary>
    [JsonPropertyName("propagation_delay")]
    public string? PropagationDelay { get; set; }

    /// <summary>
    /// Maximum time to wait for challenge record to propagate.
    /// </summary>
    [JsonPropertyName("propagation_timeout")]
    public string? PropagationTimeout { get; set; }

    /// <summary>
    /// Preferred DNS resolvers.
    /// </summary>
    [JsonPropertyName("resolvers")]
    public List<string>? Resolvers { get; set; }

    /// <summary>
    /// Override the domain name used for the DNS challenge record.
    /// </summary>
    [JsonPropertyName("override_domain")]
    public string? OverrideDomain { get; set; }

    /// <summary>
    /// The DNS provider.
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    /// <summary>
    /// Access Key ID for Alibaba Cloud.
    /// </summary>
    [JsonPropertyName("access_key_id")]
    public string? AccessKeyId { get; set; }

    /// <summary>
    /// Access Key Secret for Alibaba Cloud.
    /// </summary>
    [JsonPropertyName("access_key_secret")]
    public string? AccessKeySecret { get; set; }

    /// <summary>
    /// Region ID for Alibaba Cloud.
    /// </summary>
    [JsonPropertyName("region_id")]
    public string? RegionId { get; set; }

    /// <summary>
    /// Security Token for Alibaba Cloud.
    /// </summary>
    [JsonPropertyName("security_token")]
    public string? SecurityToken { get; set; }

    /// <summary>
    /// API Token for Cloudflare.
    /// </summary>
    [JsonPropertyName("api_token")]
    public string? ApiToken { get; set; }

    /// <summary>
    /// Zone Token for Cloudflare.
    /// </summary>
    [JsonPropertyName("zone_token")]
    public string? ZoneToken { get; set; }

    /// <summary>
    /// Username for ACME-DNS.
    /// </summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>
    /// Password for ACME-DNS.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// Subdomain for ACME-DNS.
    /// </summary>
    [JsonPropertyName("subdomain")]
    public string? Subdomain { get; set; }

    /// <summary>
    /// Server URL for ACME-DNS.
    /// </summary>
    [JsonPropertyName("server_url")]
    public string? ServerUrl { get; set; }
}