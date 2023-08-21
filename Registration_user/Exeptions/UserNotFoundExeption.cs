using EfCore.Exceptions;
using System.Runtime.Serialization;

namespace Registration_user.Exeptions;

[Serializable]
internal class UserNotFoundExeption : BaseNotFoundException
{
    public UserNotFoundExeption()
    {
    }

    public UserNotFoundExeption(string? message) : base(message)
    {
    }

    public UserNotFoundExeption(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UserNotFoundExeption(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}