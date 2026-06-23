namespace SingBoxLib.Configuration.Shared;

/// <summary>
/// Represents uTLS configuration settings.
/// </summary>
public sealed class UtlsConfig
{
    /// <summary>
    /// Gets or sets whether uTLS is enabled.
    /// </summary>
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the uTLS fingerprint.
    /// </summary>
    [JsonProperty("fingerprint")]
    public string? Fingerprint { get; set; }
}

/// <summary>
/// Constants representing uTLS fingerprints.
/// </summary>
public static class UtlsFingerprints
{
    /// <summary>
    /// Chrome fingerprint.
    /// </summary>
    public const string Chrome = "chrome";

    /// <summary>
    /// Firefox fingerprint.
    /// </summary>
    public const string Firefox = "firefox";

    /// <summary>
    /// Edge fingerprint.
    /// </summary>
    public const string Edge = "edge";

    /// <summary>
    /// Safari fingerprint.
    /// </summary>
    public const string Safari = "safari";

    /// <summary>
    /// 360 browser fingerprint.
    /// </summary>
    public const string _360 = "360";

    /// <summary>
    /// QQ browser fingerprint.
    /// </summary>
    public const string Qq = "qq";

    /// <summary>
    /// iOS client fingerprint.
    /// </summary>
    public const string Ios = "ios";

    /// <summary>
    /// Android client fingerprint.
    /// </summary>
    public const string Android = "android";

    /// <summary>
    /// Random fingerprint.
    /// </summary>
    public const string Random = "random";

    /// <summary>
    /// Randomized fingerprint.
    /// </summary>
    public const string Randomized = "randomized";
}