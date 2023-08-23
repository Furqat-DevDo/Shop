using Registration.Exceptions;
using System.Runtime.Serialization;

namespace Registration.Services
{
    [Serializable]
    internal class WrongInputException : BaseInvalidDataException
    {
        public WrongInputException()
        {
        }

        public WrongInputException(string? message) : base(message)
        {
        }

        public WrongInputException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}