using SingBoxLib.Parsing;

namespace SingBoxLib.Runtime.Testing;

public class UrlTestResult
{
    public ProfileItem Profile { get; set; } = null!;
    public int Delay { get; set; }
    public bool Success { get; set; }
}