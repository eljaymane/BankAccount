using BankAccount.Core.Model.Accounts;
using BankAccount.Core.Model.Operations;
using System.Collections.Generic;

namespace BankAccount.Core
{
    public interface IAccountOperation
    {
        Account Deposit(Account a, double amount);
        Account Withdraw(Account a, double amount);
        Account AddOperation(Account account, Operation operation);

        List<Operation> GetOperations(Account a);
    }
}