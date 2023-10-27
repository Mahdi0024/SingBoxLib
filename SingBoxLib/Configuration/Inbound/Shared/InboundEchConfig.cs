namespace SingBoxLib.Configuration.Inbound.Shared;

public class InboundEchConfig
{
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    [JsonProperty("pq_signature_schemes_enabled")]
    public bool? PqSignatureSchemesEnabled { get; set; }

    [JsonProperty("dynamic_record_sizing_disabled")]
    public bool? DynamicRecordSizingDisabled { get; set; }

    [JsonProperty("key")]
    public List<string>? Key { get; set; }

    [JsonProperty("key_path")]
    public string? KeyPath { get; set; }
}
