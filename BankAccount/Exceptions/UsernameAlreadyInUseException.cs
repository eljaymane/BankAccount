using System;
using System.Runtime.Serialization;

namespace BankAccount.Core.Exceptions
{
    [Serializable]
    public class UsernameAlreadyInUseException : Exception
    {
        const string usernameAlreadyInUseMessage = "The username is alreadyin use, please try again with a different one !";
        public UsernameAlreadyInUseException()
        {
        }

        public UsernameAlreadyInUseException(string message) : base(message)
        {
        }

        public UsernameAlreadyInUseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UsernameAlreadyInUseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => usernameAlreadyInUseMessage;
    }
}