using System;
using System.Runtime.Serialization;

namespace BankAccount.ConsoleApp.BankAccount.Exceptions
{
    [Serializable]
    public class CouldNotWithdrawException : Exception
    {
        const string outOfBalanceMessage = "The amount your are trying to withdraw is greater than your balance.";
        public CouldNotWithdrawException()
        {
        }

        public CouldNotWithdrawException(string? message) : base(message)
        {

        }

        public CouldNotWithdrawException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CouldNotWithdrawException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => outOfBalanceMessage;
    }
}