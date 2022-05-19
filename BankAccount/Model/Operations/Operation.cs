using System;

namespace BankAccount.Core.Model.Operations
{
    public class Operation
    {
        public OperationType operationType { get; set; }

        private DateTime now;
        public DateTime date { get; set; }
        public double amount { get; set; }
        public double balance { get; set; }   
    }
}