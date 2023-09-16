using System.Runtime.Serialization;

namespace Registration.Application.Exceptions
{
    [Serializable]
    internal class BaseInternalServerError : Exception
    {
        public BaseInternalServerError()
        {
        }

        public BaseInternalServerError(string? message) : base(message)
        {
        }

        public BaseInternalServerError(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BaseInternalServerError(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
