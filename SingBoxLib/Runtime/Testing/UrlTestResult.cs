namespace SingBoxLib.Runtime.Testing;

public readonly struct UrlTestResult
{
    public required ProfileItem Profile { get; init; }
    public          int         Delay   { get; init; }
    public required bool        Success { get; init; }
}