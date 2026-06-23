namespace SingBoxLib.Exceptions;

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
}