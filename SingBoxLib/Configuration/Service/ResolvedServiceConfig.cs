namespace SingBoxLib.Configuration.Service;

/// <summary>
/// Represents the fake systemd-resolved DNS service configuration.
/// </summary>
public sealed class ResolvedServiceConfig : ServiceWithListenFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ResolvedServiceConfig"/> class.
    /// </summary>
    public ResolvedServiceConfig()
    {
        Type = "resolved";
    }
}
