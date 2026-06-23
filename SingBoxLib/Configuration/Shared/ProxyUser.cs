namespace SingBoxLib.Configuration.Shared;

/// <summary>
/// Represents proxy user credentials.
/// </summary>
public sealed class ProxyUser
{
    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }
}