namespace SingBoxLib.Configuration.Route;

public sealed class RouteRule : RouteRuleBase
{
    [JsonProperty("inbound")]
    public List<string>? Inbound { get; set; }

    [JsonProperty("ip_version")]
    public int? IpVersion { get; set; }

    [JsonProperty("auth_user")]
    public List<string>? AuthUser { get; set; }

    [JsonProperty("protocol")]
    public List<string>? Protocol { get; set; }

    [JsonProperty("network")]
    public List<string>? Network { get; set; }

    [JsonProperty("domain")]
    public List<string>? Domain { get; set; }

    [JsonProperty("domain_suffix")]
    public List<string>? DomainSuffix { get; set; }

    [JsonProperty("domain_keyword")]
    public List<string>? DomainKeyword { get; set; }

    [JsonProperty("domain_regex")]
    public List<string>? DomainRegex { get; set; }

    [JsonProperty("source_ip_cidr")]
    public List<string>? SourceIpCidr { get; set; }

    [JsonProperty("ip_is_private")]
    public bool? IpIsPrivate { get; set; }

    [JsonProperty("ip_cidr")]
    public List<string>? IpCidr { get; set; }

    [JsonProperty("source_ip_is_private")]
    public bool? SourceIpIsPrivate { get; set; }

    [JsonProperty("source_port")]
    public List<int>? SourcePort { get; set; }

    [JsonProperty("source_port_range")]
    public List<string>? SourcePortRange { get; set; }

    [JsonProperty("port")]
    public List<int>? Port { get; set; }

    [JsonProperty("port_range")]
    public List<string>? PortRange { get; set; }

    [JsonProperty("process_name")]
    public List<string>? ProcessName { get; set; }

    [JsonProperty("process_path")]
    public List<string>? ProcessPath { get; set; }

    [JsonProperty("process_path_regex")]
    public List<string>? ProcessPathRegex { get; set; }

    [JsonProperty("package_name")]
    public List<string>? PackageName { get; set; }

    [JsonProperty("user")]
    public List<string>? User { get; set; }
    [JsonProperty("user_id")]
    public List<int>? UserId { get; set; }

    [JsonProperty("clash_mode")]
    public string? ClashMode { get; set; }

    [JsonProperty("network_type")]
    public List<string>? NetworkType { get; set; }

    [JsonProperty("network_is_expensive")]
    public bool? NetworkIsExpensive { get; set; }

    [JsonProperty("network_is_constrained")]
    public bool? NetworkIsConstrained { get; set; }

    [JsonProperty("wifi_ssid")]
    public List<string>? WifiSSID { get; set; }

    [JsonProperty("wifi_bssid")]
    public List<string>? WifiBSSID { get; set; }

    [JsonProperty("rule_set_ip_cidr_match_source")]
    public bool? RuleSetIpCidrMatchSource { get; set; }

    [JsonProperty("invert")]
    public bool? Invert { get; set; }

    [JsonProperty("action")]
    public required RuleAction Action { get; set; }
}