using BankAccount.Core.Model.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Core.Model.Accounts.AccountOperations.Events.OperationDone
{
    public class OperationDoneEventArgs : EventArgs
    {
        public double amount { get; set; }

        public Account account { get; set; }
        public OperationType operationType { get; set; }
    }
}
