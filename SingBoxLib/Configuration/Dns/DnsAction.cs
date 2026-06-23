namespace SingBoxLib.Configuration.Dns;
/// <summary>
/// Represents a DNS action to be executed.
/// </summary>
public sealed class DnsAction
{
    /// <summary>
    /// Gets or sets the action type.
    /// </summary>
    [JsonProperty("action")]
    public string? Action { get; set; }

    /// <summary>
    /// Gets or sets the target DNS server tag.
    /// </summary>
    [JsonProperty("server")]
    public string? Server { get; set; }

    /// <summary>
    /// Gets or sets the custom TTL to write in the response.
    /// </summary>
    [JsonProperty("rewrite_ttl")]
    public int? RewriteTtl { get; set; }

    /// <summary>
    /// Gets or sets the client subnet prefix or address.
    /// </summary>
    [JsonProperty("client_subnet")]
    public string? ClientSubnet { get; set; }

    /// <summary>
    /// Gets or sets whether cache is disabled.
    /// </summary>
    [JsonProperty("disable_cache")]
    public bool? DisableCache { get; set; }

    /// <summary>
    /// Gets or sets the resolving method.
    /// </summary>
    [JsonProperty("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Gets or sets whether to disable dropping packets.
    /// </summary>
    [JsonProperty("no_drop")]
    public bool? NoDrop { get; set; }
}
