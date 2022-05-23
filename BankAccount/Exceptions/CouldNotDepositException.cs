using System;
using System.Runtime.Serialization;

namespace BankAccount.Core.Exceptions
{
    [Serializable]
    public class CouldNotDepositException : Exception
    {
        public CouldNotDepositException()
        {
        }

        public CouldNotDepositException(string? message) : base(message)
        {
        }

        public CouldNotDepositException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CouldNotDepositException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}