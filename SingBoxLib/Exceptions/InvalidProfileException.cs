using System.Runtime.Serialization;

namespace SingBoxLib.Exceptions;
[Serializable]
internal class InvalidProfileException : Exception
{
    public InvalidProfileException()
    {
    }

    public InvalidProfileException(string? message) : base(message)
    {
    }

    public InvalidProfileException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected InvalidProfileException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}