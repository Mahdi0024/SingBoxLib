namespace SingBoxLib.Configuration.Shared;

public static class MultiplexProtocols
{
    public const string SMUX = "smux";
    public const string Yamux = "yamux";

    /// <summary>
    /// used by default
    /// </summary>
    public const string h2mux = "h2mux";
}