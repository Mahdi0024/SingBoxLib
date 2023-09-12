namespace SingBoxLib.Configuration.Shared;

public sealed class UtlsConfig
{
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    [JsonProperty("fingerprint")]
    public string? Fingerprint { get; set; }
}

public static class UtlsFingerprints
{
    public const string Chrome = "chrome";
    public const string Firefox = "firefox";
    public const string Edge = "edge";
    public const string Safari = "safari";
    public const string _360 = "360";
    public const string Qq = "qq";
    public const string Ios = "ios";
    public const string Android = "android";
    public const string Random = "random";
    public const string Randomized = "randomized";
}