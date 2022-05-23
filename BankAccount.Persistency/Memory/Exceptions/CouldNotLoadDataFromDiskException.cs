using System;
using System.Runtime.Serialization;

namespace BankAccount.Persistency.Memory.Exceptions
{
    [Serializable]
    internal class CouldNotLoadDataFromDiskException : Exception
    {
        public CouldNotLoadDataFromDiskException()
        {
        }

        public CouldNotLoadDataFromDiskException(string message) : base(message)
        {
        }

        public CouldNotLoadDataFromDiskException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CouldNotLoadDataFromDiskException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}