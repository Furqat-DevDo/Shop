using EfCore.Exceptions;
using System.Runtime.Serialization;

namespace Registration_user.Exeptions;

[Serializable]
internal class UnableToUpdateSaveChanges : BaseNotFoundException
{
    public UnableToUpdateSaveChanges()
    {
    }

    public UnableToUpdateSaveChanges(string? message) : base(message)
    {
    }

    public UnableToUpdateSaveChanges(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UnableToUpdateSaveChanges(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}