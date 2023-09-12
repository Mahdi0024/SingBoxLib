using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Ntp;

public sealed class NtpConfig : OutboundWithDialFields
{
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("interval")]
    public string? Interval { get; set; }

    // hide unused properties.
    private new string? Type { get; set; }

    private new string? Tag { get; set; }
}