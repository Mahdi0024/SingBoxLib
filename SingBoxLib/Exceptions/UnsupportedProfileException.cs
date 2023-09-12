using System.Runtime.Serialization;

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

    protected UnsupportedProfileException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}