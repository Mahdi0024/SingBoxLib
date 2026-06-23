namespace SingBoxLib.Configuration.Shared;

/// <summary>
/// Represents proxy user credentials.
/// </summary>
public sealed class ProxyUser
{
    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    [JsonProperty("username")]
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    [JsonProperty("password")]
    public string? Password { get; set; }
}