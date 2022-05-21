using BankAccount.Core.Model.Accounts;
using BankAccount.Core.Model.Operations;
using System;
using System.Collections.Generic;

namespace BankAccount.Core.Ports
{
    public class AccountOperation : IAccountOperation
    {

        public Account Withdraw(Account a, double amount)
        {
            a.balance -= amount;
            a.modifiedAt = DateTime.Now;
            return a;
        }
        public Account Deposit(Account a, double amount)
        {
            a.balance += amount;
            a.modifiedAt = DateTime.Now;
            return a;
        }

        public List<Operation> GetOperations(Account a)
        {
            a.modifiedAt = DateTime.Now;
            return a.operations;
        }

        public Account AddOperation(Account account, Operation operation)
        {
            account.operations.Add(operation);
            account.modifiedAt= operation.date;
            return account;

        }
        
    }
}
