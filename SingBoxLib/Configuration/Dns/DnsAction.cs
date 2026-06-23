namespace SingBoxLib.Configuration.Dns;
/// <summary>
/// Represents a DNS action to be executed.
/// </summary>
public sealed class DnsAction
{
    /// <summary>
    /// Gets or sets the action type.
    /// </summary>
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    /// <summary>
    /// Gets or sets the target DNS server tag.
    /// </summary>
    [JsonPropertyName("server")]
    public string? Server { get; set; }

    /// <summary>
    /// Gets or sets the custom TTL to write in the response.
    /// </summary>
    [JsonPropertyName("rewrite_ttl")]
    public int? RewriteTtl { get; set; }

    /// <summary>
    /// Gets or sets the client subnet prefix or address.
    /// </summary>
    [JsonPropertyName("client_subnet")]
    public string? ClientSubnet { get; set; }

    /// <summary>
    /// Gets or sets whether cache is disabled.
    /// </summary>
    [JsonPropertyName("disable_cache")]
    public bool? DisableCache { get; set; }

    /// <summary>
    /// Gets or sets the resolving method.
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Gets or sets whether to disable dropping packets.
    /// </summary>
    [JsonPropertyName("no_drop")]
    public bool? NoDrop { get; set; }
}
