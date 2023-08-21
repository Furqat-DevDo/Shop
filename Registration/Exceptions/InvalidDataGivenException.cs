using Registration.Exceptions;
using System.Runtime.Serialization;

namespace Registration.Services
{
    [Serializable]
    internal class InvalidDataGivenException : BaseInvalidDataException
    {
        public InvalidDataGivenException()
        {
        }

        public InvalidDataGivenException(string? message) : base(message)
        {
        }

        public InvalidDataGivenException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidDataGivenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}