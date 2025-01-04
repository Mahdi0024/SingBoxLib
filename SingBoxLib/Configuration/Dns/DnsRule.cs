using SingboxLib.Configuration.Dns;
using SingBoxLib.Configuration.Converters;
using SingBoxLib.Configuration.Dns.Abstract;

namespace SingBoxLib.Configuration.Dns;

public sealed class DnsRule : DnsRuleBase
{
    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("inbound")]
    public List<string>? Inbound { get; set; }

    [JsonProperty("ip_version")]
    public int? IpVersion { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<object>))]
    [JsonProperty("query_type")]
    public List<object>? QueryType { get; set; }

    [JsonProperty("network")]
    public string? Network { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("auth_user")]
    public List<string>? AuthUser { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("protocol")]
    public List<string>? Protocol { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("domain")]
    public List<string>? Domain { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("domain_suffix")]
    public List<string>? DomainSuffix { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("domain_keyword")]
    public List<string>? DomainKeyword { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("domain_regex")]
    public List<string>? DomainRegex { get; set; }

    [JsonProperty("geoip")]
    public string? Geoip { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("source_ip_cidr")]
    public List<string>? SourceIpCidr { get; set; }

    [JsonProperty("source_ip_is_private")]
    public bool? SourceIpIsPrivate { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<int>))]
    [JsonProperty("source_port")]
    public List<int>? SourcePort { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("source_port_range")]
    public List<string>? SourcePortRange { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<int>))]
    [JsonProperty("port")]
    public List<int>? Port { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("port_range")]
    public List<string>? PortRange { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("process_name")]
    public List<string>? ProcessName { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("process_path")]
    public List<string>? ProcessPath { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("package_name")]
    public List<string>? PackageName { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("user")]
    public List<string>? User { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<int>))]
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
    public string? WifiSsid { get; set; }

    [JsonProperty("wifi_bssid")]
    public string? WifiBssid { get; set; }

    [JsonProperty("rule_set")]
    public List<string>? RuleSet { get; set; }

    [JsonProperty("invert")]
    public bool? Invert { get; set; }

    [JsonProperty("rule_set_ip_cidr_match_source")]
    public bool? RuleSetIpCidrMatchSource { get; set; }

    [JsonConverter(typeof(SingleValueJsonConverter<string>))]
    [JsonProperty("outbound")]
    public List<string>? Outbound { get; set; }

    [JsonProperty("action")]
    public DnsAction? Action { get; set; }

    [JsonProperty("ip_cidr")]
    public List<string>? IpCidr { get; set; }

    [JsonProperty("ip_is_private")]
    public bool? IpIsPrivate { get; set; }

    [JsonProperty("rule_set_ip_cidr_accept_empty")]
    public bool? RuleSetIpCidrAcceptEmpty { get; set; }

}