namespace SingBoxLib.Configuration.Dns;

/// <summary>
/// Represents a rule for routing DNS queries or matching DNS responses.
/// </summary>
public sealed class DnsRule : DnsRuleBase
{
    /// <summary>
    /// Matches inbound connection tags.
    /// </summary>
    [JsonPropertyName("inbound")]
    public List<string>? Inbound { get; set; }

    /// <summary>
    /// Matches IP version.
    /// </summary>
    [JsonPropertyName("ip_version")]
    public int? IpVersion { get; set; }

    /// <summary>
    /// Matches query types.
    /// </summary>
    [JsonPropertyName("query_type")]
    public List<object>? QueryType { get; set; }

    /// <summary>
    /// Matches connection network (tcp/udp).
    /// </summary>
    [JsonPropertyName("network")]
    public string? Network { get; set; }

    /// <summary>
    /// Matches authenticated usernames.
    /// </summary>
    [JsonPropertyName("auth_user")]
    public List<string>? AuthUser { get; set; }

    /// <summary>
    /// Matches connection protocols.
    /// </summary>
    [JsonPropertyName("protocol")]
    public List<string>? Protocol { get; set; }

    /// <summary>
    /// Matches domain names.
    /// </summary>
    [JsonPropertyName("domain")]
    public List<string>? Domain { get; set; }

    /// <summary>
    /// Matches domain suffixes.
    /// </summary>
    [JsonPropertyName("domain_suffix")]
    public List<string>? DomainSuffix { get; set; }

    /// <summary>
    /// Matches domain keywords.
    /// </summary>
    [JsonPropertyName("domain_keyword")]
    public List<string>? DomainKeyword { get; set; }

    /// <summary>
    /// Matches domain regular expressions.
    /// </summary>
    [JsonPropertyName("domain_regex")]
    public List<string>? DomainRegex { get; set; }

    /// <summary>
    /// Matches source IP CIDRs.
    /// </summary>
    [JsonPropertyName("source_ip_cidr")]
    public List<string>? SourceIpCidr { get; set; }

    /// <summary>
    /// Matches if source IP is private.
    /// </summary>
    [JsonPropertyName("source_ip_is_private")]
    public bool? SourceIpIsPrivate { get; set; }

    /// <summary>
    /// Matches source ports.
    /// </summary>
    [JsonPropertyName("source_port")]
    public List<int>? SourcePort { get; set; }

    /// <summary>
    /// Matches source port ranges.
    /// </summary>
    [JsonPropertyName("source_port_range")]
    public List<string>? SourcePortRange { get; set; }

    /// <summary>
    /// Matches destination ports.
    /// </summary>
    [JsonPropertyName("port")]
    public List<int>? Port { get; set; }

    /// <summary>
    /// Matches destination port ranges.
    /// </summary>
    [JsonPropertyName("port_range")]
    public List<string>? PortRange { get; set; }

    /// <summary>
    /// Matches process names.
    /// </summary>
    [JsonPropertyName("process_name")]
    public List<string>? ProcessName { get; set; }

    /// <summary>
    /// Matches process paths.
    /// </summary>
    [JsonPropertyName("process_path")]
    public List<string>? ProcessPath { get; set; }

    /// <summary>
    /// Matches package names.
    /// </summary>
    [JsonPropertyName("package_name")]
    public List<string>? PackageName { get; set; }

    /// <summary>
    /// Matches user names.
    /// </summary>
    [JsonPropertyName("user")]
    public List<string>? User { get; set; }

    /// <summary>
    /// Matches user IDs.
    /// </summary>
    [JsonPropertyName("user_id")]
    public List<int>? UserId { get; set; }

    /// <summary>
    /// Matches clash mode.
    /// </summary>
    [JsonPropertyName("clash_mode")]
    public string? ClashMode { get; set; }

    /// <summary>
    /// Matches network types.
    /// </summary>
    [JsonPropertyName("network_type")]
    public List<string>? NetworkType { get; set; }

    /// <summary>
    /// Matches if network is expensive.
    /// </summary>
    [JsonPropertyName("network_is_expensive")]
    public bool? NetworkIsExpensive { get; set; }

    /// <summary>
    /// Matches if network is constrained.
    /// </summary>
    [JsonPropertyName("network_is_constrained")]
    public bool? NetworkIsConstrained { get; set; }

    /// <summary>
    /// Matches Wifi SSIDs.
    /// </summary>
    [JsonPropertyName("wifi_ssid")]
    public string? WifiSsid { get; set; }

    /// <summary>
    /// Matches Wifi BSSIDs.
    /// </summary>
    [JsonPropertyName("wifi_bssid")]
    public string? WifiBssid { get; set; }

    /// <summary>
    /// Matches rule-sets.
    /// </summary>
    [JsonPropertyName("rule_set")]
    public List<string>? RuleSet { get; set; }

    /// <summary>
    /// Matches android package name using regular expression.
    /// </summary>
    [JsonPropertyName("package_name_regex")]
    public List<string>? PackageNameRegex { get; set; }

    /// <summary>
    /// Match interface address.
    /// </summary>
    [JsonPropertyName("interface_address")]
    public Dictionary<string, List<string>>? InterfaceAddress { get; set; }

    /// <summary>
    /// Matches network interface address.
    /// </summary>
    [JsonPropertyName("network_interface_address")]
    public Dictionary<string, List<string>>? NetworkInterfaceAddress { get; set; }

    /// <summary>
    /// Match default interface address.
    /// </summary>
    [JsonPropertyName("default_interface_address")]
    public List<string>? DefaultInterfaceAddress { get; set; }

    /// <summary>
    /// Match source device MAC address.
    /// </summary>
    [JsonPropertyName("source_mac_address")]
    public List<string>? SourceMacAddress { get; set; }

    /// <summary>
    /// Match source device hostname.
    /// </summary>
    [JsonPropertyName("source_hostname")]
    public List<string>? SourceHostname { get; set; }

    /// <summary>
    /// Match specified DNS servers' preferred domains.
    /// </summary>
    [JsonPropertyName("preferred_by")]
    public List<string>? PreferredBy { get; set; }

    /// <summary>
    /// Match when the DNS query response contains at least one address.
    /// </summary>
    [JsonPropertyName("ip_accept_any")]
    public bool? IpAcceptAny { get; set; }

    /// <summary>
    /// Match DNS response code.
    /// </summary>
    [JsonPropertyName("response_rcode")]
    public string? ResponseRcode { get; set; }

    /// <summary>
    /// Match DNS answer records.
    /// </summary>
    [JsonPropertyName("response_answer")]
    public List<string>? ResponseAnswer { get; set; }

    /// <summary>
    /// Match DNS name server records.
    /// </summary>
    [JsonPropertyName("response_ns")]
    public List<string>? ResponseNs { get; set; }

    /// <summary>
    /// Match DNS extra records.
    /// </summary>
    [JsonPropertyName("response_extra")]
    public List<string>? ResponseExtra { get; set; }

    /// <summary>
    /// Inverts the match.
    /// </summary>
    [JsonPropertyName("invert")]
    public bool? Invert { get; set; }

    /// <summary>
    /// Matches rule-set IP CIDR against source IP.
    /// </summary>
    [JsonPropertyName("rule_set_ip_cidr_match_source")]
    public bool? RuleSetIpCidrMatchSource { get; set; }

    /// <summary>
    /// When true, DNS responses are evaluated.
    /// </summary>
    [JsonPropertyName("match_response")]
    public bool? MatchResponse { get; set; }

    /// <summary>
    /// The action to perform.
    /// </summary>
    [JsonPropertyName("action")]
    public DnsAction? Action { get; set; }

    /// <summary>
    /// Matches process paths using regular expression.
    /// </summary>
    [JsonPropertyName("process_path_regex")]
    public List<string>? ProcessPathRegex { get; set; }

    /// <summary>
    /// Matches IP CIDRs in response.
    /// </summary>
    [JsonPropertyName("ip_cidr")]
    public List<string>? IpCidr { get; set; }

    /// <summary>
    /// Matches if IP in response is private.
    /// </summary>
    [JsonPropertyName("ip_is_private")]
    public bool? IpIsPrivate { get; set; }

    /// <summary>
    /// Make ip_cidr rules in rule-sets accept empty query response.
    /// </summary>
    [JsonPropertyName("rule_set_ip_cidr_accept_empty")]
    public bool? RuleSetIpCidrAcceptEmpty { get; set; }

    /// <summary>
    /// Matches outbounds.
    /// </summary>
    [JsonPropertyName("outbound")]
    public List<string>? Outbound { get; set; }
}