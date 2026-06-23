namespace SingBoxLib.Exceptions;

public sealed class UnsupportedProfileException : Exception
{
    public UnsupportedProfileException()
    {
    }

    public UnsupportedProfileException(string? message) : base(message)
    {
    }

    public UnsupportedProfileException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}