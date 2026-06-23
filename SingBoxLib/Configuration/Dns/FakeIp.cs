namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents Fake IP configuration settings.
/// </summary>
public sealed class FakeIp
{
    /// <summary>
    /// Gets or sets whether Fake IP is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the IPv4 address range for Fake IP.
    /// </summary>
    [JsonPropertyName("inet4_range")]
    public string? Inet4Range { get; set; }

    /// <summary>
    /// Gets or sets the IPv6 address range for Fake IP.
    /// </summary>
    [JsonPropertyName("inet6_range")]
    public string? Inet6Range { get; set; }
}