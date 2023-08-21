using EfCore.Exceptions;
using System.Runtime.Serialization;

namespace Registration_user.Exeptions;

[Serializable]
internal class UnableToCreateSaveChanges : BaseNotFoundException
{
    public UnableToCreateSaveChanges()
    {
    }

    public UnableToCreateSaveChanges(string? message) : base(message)
    {
    }

    public UnableToCreateSaveChanges(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UnableToCreateSaveChanges(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}