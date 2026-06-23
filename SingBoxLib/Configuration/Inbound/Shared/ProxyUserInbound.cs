namespace SingBoxLib.Configuration.Inbound.Shared;

/// <summary>
/// Represents user credentials for inbound proxies.
/// </summary>
public sealed class ProxyUserInbound
{
    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    [JsonProperty("name")]
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    [JsonProperty("password")]
    public string? Password { get; set; }
}