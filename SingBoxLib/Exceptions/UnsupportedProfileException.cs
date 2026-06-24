using System;

namespace SingBoxLib.Exceptions;

/// <summary>
/// The exception that is thrown when a proxy profile format is not supported.
/// </summary>
public sealed class UnsupportedProfileException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnsupportedProfileException"/> class.
    /// </summary>
    public UnsupportedProfileException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnsupportedProfileException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public UnsupportedProfileException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnsupportedProfileException"/> class with a specified error message and inner exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The inner exception that caused the current exception.</param>
    public UnsupportedProfileException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
