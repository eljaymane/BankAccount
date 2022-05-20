using System;

namespace BankAccount.Core.Model.Operations
{
    public class Operation
    {
        public OperationType operationType { get; set; }
        public DateTime date { get; set; }
        public double amount { get; set; }
        public double balance { get; set; }

        public override string ToString()
        {
            return String.Format("[{0}] Action : {1} Amount : {2} Balance : {3}", date, operationType, amount, Math.Round(balance,2));
        }
    }
}