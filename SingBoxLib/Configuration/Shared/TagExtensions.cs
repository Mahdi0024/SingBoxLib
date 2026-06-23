namespace SingBoxLib.Configuration.Shared;

/// <summary>
/// Provides extension methods for fluent inbound tag configuration.
/// </summary>
public static class InboundTagExtensions
{
    /// <summary>
    /// Sets the tag of the inbound configuration and returns the same instance.
    /// </summary>
    /// <typeparam name="T">The type of the inbound configuration.</typeparam>
    /// <param name="config">The inbound configuration instance.</param>
    /// <param name="tag">The tag to set.</param>
    /// <returns>The same inbound configuration instance.</returns>
    public static T WithTag<T>(this T config, string? tag) where T : InboundConfig
    {
        config.Tag = tag;
        return config;
    }
}

/// <summary>
/// Provides extension methods for fluent outbound tag configuration.
/// </summary>
public static class OutboundTagExtensions
{
    /// <summary>
    /// Sets the tag of the outbound configuration and returns the same instance.
    /// </summary>
    /// <typeparam name="T">The type of the outbound configuration.</typeparam>
    /// <param name="config">The outbound configuration instance.</param>
    /// <param name="tag">The tag to set.</param>
    /// <returns>The same outbound configuration instance.</returns>
    public static T WithTag<T>(this T config, string? tag) where T : OutboundConfig
    {
        config.Tag = tag;
        return config;
    }
}
