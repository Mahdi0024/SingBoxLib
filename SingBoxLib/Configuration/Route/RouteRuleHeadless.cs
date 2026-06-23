namespace SingBoxLib.Configuration.Route;

/// <summary>
/// Represents a headless route rule.
/// </summary>
public sealed class RouteRuleHeadless: RouteRuleHeadlessBase
{
    /// <summary>
    /// Gets or sets the list of query types.
    /// </summary>
    [JsonProperty("query_type")]
    public List<object>? QueryType { get; set; }

    /// <summary>
    /// Gets or sets the list of networks.
    /// </summary>
    [JsonProperty("network")]
    public List<string>? Network { get; set; }

    /// <summary>
    /// Gets or sets the list of domains.
    /// </summary>
    [JsonProperty("domain")]
    public List<string>? Domain { get; set; }

    /// <summary>
    /// Gets or sets the list of domain suffixes.
    /// </summary>
    [JsonProperty("domain_suffix")]
    public List<string>? DomainSuffix { get; set; }

    /// <summary>
    /// Gets or sets the list of domain keywords.
    /// </summary>
    [JsonProperty("domain_keyword")]
    public List<string>? DomainKeyword { get; set; }

    /// <summary>
    /// Gets or sets the list of domain regular expressions.
    /// </summary>
    [JsonProperty("domain_regex")]
    public List<string>? DomainRegex { get; set; }

    /// <summary>
    /// Gets or sets the list of source IP CIDRs.
    /// </summary>
    [JsonProperty("source_ip_cidr")]
    public List<string>? SourceIpCidr { get; set; }

    /// <summary>
    /// Gets or sets the list of destination IP CIDRs.
    /// </summary>
    [JsonProperty("ip_cidr")]
    public List<string>? IpCidr { get; set; }

    /// <summary>
    /// Gets or sets the list of source ports.
    /// </summary>
    [JsonProperty("source_port")]
    public List<int>? SourcePort { get; set; }

    /// <summary>
    /// Gets or sets the list of source port ranges.
    /// </summary>
    [JsonProperty("source_port_range")]
    public List<string>? SourcePortRange { get; set; }

    /// <summary>
    /// Gets or sets the list of destination ports.
    /// </summary>
    [JsonProperty("port")]
    public List<int>? Port { get; set; }

    /// <summary>
    /// Gets or sets the list of destination port ranges.
    /// </summary>
    [JsonProperty("port_range")]
    public List<string>? PortRange { get; set; }

    /// <summary>
    /// Gets or sets the list of process names.
    /// </summary>
    [JsonProperty("process_name")]
    public List<string>? ProcessName { get; set; }

    /// <summary>
    /// Gets or sets the list of process paths.
    /// </summary>
    [JsonProperty("process_path")]
    public List<string>? ProcessPath { get; set; }

    /// <summary>
    /// Gets or sets the list of process path regular expressions.
    /// </summary>
    [JsonProperty("process_path_regex")]
    public List<string>? ProcessPathRegex { get; set; }

    /// <summary>
    /// Gets or sets the list of package names.
    /// </summary>
    [JsonProperty("package_name")]
    public List<string>? PackageName { get; set; }

    /// <summary>
    /// Gets or sets the list of network types.
    /// </summary>
    [JsonProperty("network_type")]
    public List<string>? NetworkType { get; set; }

    /// <summary>
    /// Gets or sets whether the network is expensive.
    /// </summary>
    [JsonProperty("network_is_expensive")]
    public bool? IsNetworkExpensive { get; set; }

    /// <summary>
    /// Gets or sets whether the network is constrained.
    /// </summary>
    [JsonProperty("network_is_constrained")]
    public bool? IsNetworkConstrained { get; set; }

    /// <summary>
    /// Gets or sets the list of WiFi SSIDs.
    /// </summary>
    [JsonProperty("wifi_ssid")]
    public List<string>? WifiSsid { get; set; }

    /// <summary>
    /// Gets or sets the list of WiFi BSSIDs.
    /// </summary>
    [JsonProperty("wifi_bssid")]
    public List<string>? WifiBssid { get; set; }

    /// <summary>
    /// Gets or sets whether to invert the rule match.
    /// </summary>
    [JsonProperty("invert")]
    public bool? Invert { get; set; }
}