using System;

namespace LoggerApp.Exceptions;

public sealed class BusinessException : Exception
{
    public BusinessException()
    {
    }

    public BusinessException(string message) : base(message)
    {
    }
}