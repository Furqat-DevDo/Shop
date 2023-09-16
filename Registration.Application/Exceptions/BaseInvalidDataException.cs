using System.Runtime.Serialization;

namespace Registration.Application.Exceptions
{
    public class BaseInvalidDataException : Exception
    {
        public BaseInvalidDataException()
        {

        }

        public BaseInvalidDataException(string? message) : base(message)
        {
        }

        public BaseInvalidDataException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BaseInvalidDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
