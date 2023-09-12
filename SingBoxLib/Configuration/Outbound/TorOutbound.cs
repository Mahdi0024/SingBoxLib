using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

public sealed class TorOutbound : OutboundWithDialFields
{
    public TorOutbound()
    {
        Type = "tor";
        Tag = "tor-out";
    }

    [JsonProperty("executable_path")]
    public string? ExecutablePath { get; set; }

    [JsonProperty("extra_args")]
    public List<string>? ExtraArgs { get; set; }

    [JsonProperty("data_directory")]
    public string? DataDirectory { get; set; }

    [JsonProperty("torrc")]
    public Torrc? Torrc { get; set; }
}

public sealed class Torrc
{
    [JsonProperty("ClientOnly")]
    public int? ClientOnly { get; set; }
}