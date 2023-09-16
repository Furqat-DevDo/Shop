using System.Runtime.Serialization;
using Registration.Application.Exceptions;

namespace Registration.Application.Users.Exceptions
{
    [Serializable]
    internal class UserNotFoundException : BaseNotFoundException
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string? message) : base(message)
        {
        }

        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
