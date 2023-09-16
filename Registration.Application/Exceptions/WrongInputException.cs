using System.Runtime.Serialization;
using Registration.Application.Exceptions;

namespace Registration.Application.Exceptions
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
