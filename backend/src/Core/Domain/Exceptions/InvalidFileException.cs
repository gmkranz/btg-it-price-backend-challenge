using System;

namespace Domain.Exceptions;

public class InvalidFileException : Exception
{
    public InvalidFileException(string message) : base(message)
    {

    }
}
