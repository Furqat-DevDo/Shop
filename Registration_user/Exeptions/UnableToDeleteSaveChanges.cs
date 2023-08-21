using EfCore.Exceptions;
using System.Runtime.Serialization;

namespace Registration_user.Exeptions;

[Serializable]
internal class UnableToDeleteSaveChanges : BaseNotFoundException
{
    public UnableToDeleteSaveChanges()
    {
    }

    public UnableToDeleteSaveChanges(string? message) : base(message)
    {
    }

    public UnableToDeleteSaveChanges(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UnableToDeleteSaveChanges(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}