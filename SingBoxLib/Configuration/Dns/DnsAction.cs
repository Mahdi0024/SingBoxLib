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
    /// Gets or sets the domain strategy.
    /// </summary>
    [JsonPropertyName("strategy")]
    public string? Strategy { get; set; }

    /// <summary>
    /// Gets or sets whether optimistic cache is disabled.
    /// </summary>
    [JsonPropertyName("disable_optimistic_cache")]
    public bool? DisableOptimisticCache { get; set; }

    /// <summary>
    /// Gets or sets the query timeout.
    /// </summary>
    [JsonPropertyName("timeout")]
    public string? Timeout { get; set; }

    /// <summary>
    /// Gets or sets the rcode.
    /// </summary>
    [JsonPropertyName("rcode")]
    public string? Rcode { get; set; }

    /// <summary>
    /// Gets or sets the predefined answers.
    /// </summary>
    [JsonPropertyName("answer")]
    public List<string>? Answer { get; set; }

    /// <summary>
    /// Gets or sets the predefined name servers.
    /// </summary>
    [JsonPropertyName("ns")]
    public List<string>? Ns { get; set; }

    /// <summary>
    /// Gets or sets the predefined extra records.
    /// </summary>
    [JsonPropertyName("extra")]
    public List<string>? Extra { get; set; }

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
