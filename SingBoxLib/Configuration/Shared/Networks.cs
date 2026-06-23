namespace SingBoxLib.Configuration.Shared;

/// <summary>
/// Constants representing network types.
/// </summary>
public static class Networks
{
    /// <summary>
    /// UDP protocol.
    /// </summary>
    public const string Udp = "udp";

    /// <summary>
    /// TCP protocol.
    /// </summary>
    public const string Tcp = "tcp";

    /// <summary>
    /// WebSocket protocol.
    /// </summary>
    public const string Websocket = "ws";

    /// <summary>
    /// gRPC protocol.
    /// </summary>
    public const string Grpc = "grpc";

    /// <summary>
    /// HTTP protocol.
    /// </summary>
    public const string Http = "http";

    /// <summary>
    /// HTTP/2 protocol.
    /// </summary>
    public const string H2 = "h2";

    /// <summary>
    /// HTTP Upgrade protocol.
    /// </summary>
    public const string HttpUpgrade = "httpupgrade";
}