using System.Runtime.Serialization;

namespace Registration.Application.Exceptions;

public class BaseNotFoundException : Exception
{
    public BaseNotFoundException()
    {
        
    }

    public BaseNotFoundException(string? message) : base(message)
    {
    }

    public BaseNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected BaseNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
