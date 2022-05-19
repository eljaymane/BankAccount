using System;
using System.Collections.Generic;
using System.Text;
using BankAccount.Core.Model.Accounts;
using BankAccount.Core.Model.Operations;

namespace BankAccount.Core.Model.OperationsAction
{
    internal interface IActionOperation
    {
        Tuple<Operation, Account> depositOperation(Account account, double amount);
        Tuple<Operation, Account> withdrawOperation(Account account, double amount);
        Tuple<Operation, List<Operation>> seeOperations(Account account);
    }
}
