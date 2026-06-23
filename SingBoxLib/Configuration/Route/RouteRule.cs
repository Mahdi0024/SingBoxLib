namespace SingBoxLib.Configuration.Route;

/// <summary>
/// Represents a route rule configuration.
/// </summary>
public sealed class RouteRule : RouteRuleBase
{
    /// <summary>
    /// Gets or sets the list of inbound tags.
    /// </summary>
    [JsonPropertyName("inbound")]
    public List<string>? Inbound { get; set; }

    /// <summary>
    /// Gets or sets the IP version (4 or 6).
    /// </summary>
    [JsonPropertyName("ip_version")]
    public int? IpVersion { get; set; }

    /// <summary>
    /// Gets or sets the list of authenticated users.
    /// </summary>
    [JsonPropertyName("auth_user")]
    public List<string>? AuthUser { get; set; }

    /// <summary>
    /// Gets or sets the list of protocols.
    /// </summary>
    [JsonPropertyName("protocol")]
    public List<string>? Protocol { get; set; }

    /// <summary>
    /// Gets or sets the list of networks.
    /// </summary>
    [JsonPropertyName("network")]
    public List<string>? Network { get; set; }

    /// <summary>
    /// Gets or sets the list of domains.
    /// </summary>
    [JsonPropertyName("domain")]
    public List<string>? Domain { get; set; }

    /// <summary>
    /// Gets or sets the list of domain suffixes.
    /// </summary>
    [JsonPropertyName("domain_suffix")]
    public List<string>? DomainSuffix { get; set; }

    /// <summary>
    /// Gets or sets the list of domain keywords.
    /// </summary>
    [JsonPropertyName("domain_keyword")]
    public List<string>? DomainKeyword { get; set; }

    /// <summary>
    /// Gets or sets the list of domain regular expressions.
    /// </summary>
    [JsonPropertyName("domain_regex")]
    public List<string>? DomainRegex { get; set; }

    /// <summary>
    /// Gets or sets the list of source IP CIDRs.
    /// </summary>
    [JsonPropertyName("source_ip_cidr")]
    public List<string>? SourceIpCidr { get; set; }

    /// <summary>
    /// Gets or sets whether the IP is private.
    /// </summary>
    [JsonPropertyName("ip_is_private")]
    public bool? IpIsPrivate { get; set; }

    /// <summary>
    /// Gets or sets the list of destination IP CIDRs.
    /// </summary>
    [JsonPropertyName("ip_cidr")]
    public List<string>? IpCidr { get; set; }

    /// <summary>
    /// Gets or sets whether the source IP is private.
    /// </summary>
    [JsonPropertyName("source_ip_is_private")]
    public bool? SourceIpIsPrivate { get; set; }

    /// <summary>
    /// Gets or sets the list of source ports.
    /// </summary>
    [JsonPropertyName("source_port")]
    public List<int>? SourcePort { get; set; }

    /// <summary>
    /// Gets or sets the list of source port ranges.
    /// </summary>
    [JsonPropertyName("source_port_range")]
    public List<string>? SourcePortRange { get; set; }

    /// <summary>
    /// Gets or sets the list of destination ports.
    /// </summary>
    [JsonPropertyName("port")]
    public List<int>? Port { get; set; }

    /// <summary>
    /// Gets or sets the list of destination port ranges.
    /// </summary>
    [JsonPropertyName("port_range")]
    public List<string>? PortRange { get; set; }

    /// <summary>
    /// Gets or sets the list of process names.
    /// </summary>
    [JsonPropertyName("process_name")]
    public List<string>? ProcessName { get; set; }

    /// <summary>
    /// Gets or sets the list of process paths.
    /// </summary>
    [JsonPropertyName("process_path")]
    public List<string>? ProcessPath { get; set; }

    /// <summary>
    /// Gets or sets the list of process path regular expressions.
    /// </summary>
    [JsonPropertyName("process_path_regex")]
    public List<string>? ProcessPathRegex { get; set; }

    /// <summary>
    /// Gets or sets the list of package names.
    /// </summary>
    [JsonPropertyName("package_name")]
    public List<string>? PackageName { get; set; }

    /// <summary>
    /// Gets or sets the list of users.
    /// </summary>
    [JsonPropertyName("user")]
    public List<string>? User { get; set; }

    /// <summary>
    /// Gets or sets the list of user IDs.
    /// </summary>
    [JsonPropertyName("user_id")]
    public List<int>? UserId { get; set; }

    /// <summary>
    /// Gets or sets the Clash mode.
    /// </summary>
    [JsonPropertyName("clash_mode")]
    public string? ClashMode { get; set; }

    /// <summary>
    /// Gets or sets the list of network types.
    /// </summary>
    [JsonPropertyName("network_type")]
    public List<string>? NetworkType { get; set; }

    /// <summary>
    /// Gets or sets whether the network is expensive.
    /// </summary>
    [JsonPropertyName("network_is_expensive")]
    public bool? NetworkIsExpensive { get; set; }

    /// <summary>
    /// Gets or sets whether the network is constrained.
    /// </summary>
    [JsonPropertyName("network_is_constrained")]
    public bool? NetworkIsConstrained { get; set; }

    /// <summary>
    /// Gets or sets the list of WiFi SSIDs.
    /// </summary>
    [JsonPropertyName("wifi_ssid")]
    public List<string>? WifiSSID { get; set; }

    /// <summary>
    /// Gets or sets the list of WiFi BSSIDs.
    /// </summary>
    [JsonPropertyName("wifi_bssid")]
    public List<string>? WifiBSSID { get; set; }

    /// <summary>
    /// Gets or sets whether to match the source IP in rule-set IP CIDRs.
    /// </summary>
    [JsonPropertyName("rule_set_ip_cidr_match_source")]
    public bool? RuleSetIpCidrMatchSource { get; set; }

    /// <summary>
    /// Gets or sets whether to invert the rule match.
    /// </summary>
    [JsonPropertyName("invert")]
    public bool? Invert { get; set; }

    /// <summary>
    /// Gets or sets the action to perform when the rule matches.
    /// </summary>
    [JsonPropertyName("action")]
    public required RuleAction Action { get; set; }
}