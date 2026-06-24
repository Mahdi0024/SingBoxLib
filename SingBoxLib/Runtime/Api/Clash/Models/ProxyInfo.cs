using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SingBoxLib.Runtime.Api.Clash.Models;

/// <summary>
/// Represents Clash proxy information.
/// </summary>
public class ProxyInfo
{
    /// <summary>
    /// Gets or sets the list of proxy node tags (for selector/url-test outbounds).
    /// </summary>
    [JsonPropertyName("all")]
    public List<string>? All { get; set; }

    /// <summary>
    /// Gets or sets the currently active proxy tag (for selector outbounds).
    /// </summary>
    [JsonPropertyName("now")]
    public string? Now { get; set; }

    /// <summary>
    /// Gets or sets the proxy type.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    /// <summary>
    /// Gets or sets the latency test history list.
    /// </summary>
    [JsonPropertyName("history")]
    public IEnumerable<UrlTestInfo>? TestHistory { get; set; }
}

/// <summary>
/// Represents individual latency test records in Clash history.
/// </summary>
public class UrlTestInfo
{
    /// <summary>
    /// Gets or sets the test execution time.
    /// </summary>
    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    /// <summary>
    /// Gets or sets the test delay value.
    /// </summary>
    [JsonPropertyName("delay")]
    public int Delay { get; set; }
}
