namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a rule for routing DNS queries or matching DNS responses.
/// </summary>
public sealed class DnsRule : DnsRuleBase
{
    /// <summary>
    /// Matches inbound connection tags.
    /// </summary>
    [JsonProperty("inbound")]
    public List<string>? Inbound { get; set; }

    /// <summary>
    /// Matches IP version.
    /// </summary>
    [JsonProperty("ip_version")]
    public int? IpVersion { get; set; }

    /// <summary>
    /// Matches query types.
    /// </summary>
    [JsonProperty("query_type")]
    public List<object>? QueryType { get; set; }

    /// <summary>
    /// Matches connection network (tcp/udp).
    /// </summary>
    [JsonProperty("network")]
    public string? Network { get; set; }

    /// <summary>
    /// Matches authenticated usernames.
    /// </summary>
    [JsonProperty("auth_user")]
    public List<string>? AuthUser { get; set; }

    /// <summary>
    /// Matches connection protocols.
    /// </summary>
    [JsonProperty("protocol")]
    public List<string>? Protocol { get; set; }

    /// <summary>
    /// Matches domain names.
    /// </summary>
    [JsonProperty("domain")]
    public List<string>? Domain { get; set; }

    /// <summary>
    /// Matches domain suffixes.
    /// </summary>
    [JsonProperty("domain_suffix")]
    public List<string>? DomainSuffix { get; set; }

    /// <summary>
    /// Matches domain keywords.
    /// </summary>
    [JsonProperty("domain_keyword")]
    public List<string>? DomainKeyword { get; set; }

    /// <summary>
    /// Matches domain regular expressions.
    /// </summary>
    [JsonProperty("domain_regex")]
    public List<string>? DomainRegex { get; set; }

    /// <summary>
    /// Matches source IP CIDRs.
    /// </summary>
    [JsonProperty("source_ip_cidr")]
    public List<string>? SourceIpCidr { get; set; }

    /// <summary>
    /// Matches if source IP is private.
    /// </summary>
    [JsonProperty("source_ip_is_private")]
    public bool? SourceIpIsPrivate { get; set; }

    /// <summary>
    /// Matches source ports.
    /// </summary>
    [JsonProperty("source_port")]
    public List<int>? SourcePort { get; set; }

    /// <summary>
    /// Matches source port ranges.
    /// </summary>
    [JsonProperty("source_port_range")]
    public List<string>? SourcePortRange { get; set; }

    /// <summary>
    /// Matches destination ports.
    /// </summary>
    [JsonProperty("port")]
    public List<int>? Port { get; set; }

    /// <summary>
    /// Matches destination port ranges.
    /// </summary>
    [JsonProperty("port_range")]
    public List<string>? PortRange { get; set; }

    /// <summary>
    /// Matches process names.
    /// </summary>
    [JsonProperty("process_name")]
    public List<string>? ProcessName { get; set; }

    /// <summary>
    /// Matches process paths.
    /// </summary>
    [JsonProperty("process_path")]
    public List<string>? ProcessPath { get; set; }

    /// <summary>
    /// Matches package names.
    /// </summary>
    [JsonProperty("package_name")]
    public List<string>? PackageName { get; set; }

    /// <summary>
    /// Matches user names.
    /// </summary>
    [JsonProperty("user")]
    public List<string>? User { get; set; }

    /// <summary>
    /// Matches user IDs.
    /// </summary>
    [JsonProperty("user_id")]
    public List<int>? UserId { get; set; }

    /// <summary>
    /// Matches clash mode.
    /// </summary>
    [JsonProperty("clash_mode")]
    public string? ClashMode { get; set; }

    /// <summary>
    /// Matches network types.
    /// </summary>
    [JsonProperty("network_type")]
    public List<string>? NetworkType { get; set; }

    /// <summary>
    /// Matches if network is expensive.
    /// </summary>
    [JsonProperty("network_is_expensive")]
    public bool? NetworkIsExpensive { get; set; }

    /// <summary>
    /// Matches if network is constrained.
    /// </summary>
    [JsonProperty("network_is_constrained")]
    public bool? NetworkIsConstrained { get; set; }

    /// <summary>
    /// Matches Wifi SSIDs.
    /// </summary>
    [JsonProperty("wifi_ssid")]
    public string? WifiSsid { get; set; }

    /// <summary>
    /// Matches Wifi BSSIDs.
    /// </summary>
    [JsonProperty("wifi_bssid")]
    public string? WifiBssid { get; set; }

    /// <summary>
    /// Matches rule-sets.
    /// </summary>
    [JsonProperty("rule_set")]
    public List<string>? RuleSet { get; set; }

    /// <summary>
    /// Inverts the match.
    /// </summary>
    [JsonProperty("invert")]
    public bool? Invert { get; set; }

    /// <summary>
    /// Matches rule-set IP CIDR against source IP.
    /// </summary>
    [JsonProperty("rule_set_ip_cidr_match_source")]
    public bool? RuleSetIpCidrMatchSource { get; set; }

    /// <summary>
    /// When true, DNS responses are evaluated.
    /// </summary>
    [JsonProperty("match_response")]
    public bool? MatchResponse { get; set; }

    /// <summary>
    /// The action to perform.
    /// </summary>
    [JsonProperty("action")]
    public DnsAction? Action { get; set; }
}