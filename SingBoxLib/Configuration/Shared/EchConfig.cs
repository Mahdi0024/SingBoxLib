namespace SingBoxLib.Configuration.Shared;

public sealed class EchConfig
{
    public bool? Enabled { get; set; }

    [JsonProperty("pq_signature_schemes_enabled")]
    public bool? PqSignatureSchemesEnabled { get; set; }

    [JsonProperty("dynamic_record_sizing_disabled")]
    public bool? DynamicRecordSizingDisabled { get; set; }

    [JsonProperty("config")]
    public string? Config { get; set; }
}