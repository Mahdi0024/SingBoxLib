namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a logical rule for DNS configuration.
/// </summary>
public sealed class DnsLogicalRule : DnsRuleBase
{
    /// <summary>
    /// Gets or sets the type of rule, which should be logical.
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the logical evaluation mode (e.g., and, or).
    /// </summary>
    [JsonProperty("mode")]
    public string? Mode { get; set; }

    /// <summary>
    /// Gets or sets the list of nested DNS rules.
    /// </summary>
    [JsonProperty("rules")]
    public List<DnsRuleBase>? Rules { get; set; }

    /// <summary>
    /// Gets or sets the action to perform if the rules match.
    /// </summary>
    [JsonProperty("action")]
    public DnsAction? Action { get; set; }

    /// <summary>
    /// Gets or sets the DNS server to route to.
    /// </summary>
    [JsonProperty("server")]
    public string? Server { get; set; }
}