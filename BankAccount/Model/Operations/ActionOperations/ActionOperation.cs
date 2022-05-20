using BankAccount.Core.Model.Accounts;
using BankAccount.Core.Model.Operations;
using BankAccount.Core.Model.OperationsAction.Exceptions;
using BankAccount.Core.Model.OperationsVerify;
using BankAccount.Core.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Core.Model.OperationsAction
{
    public class ActionOperation : IActionOperation
    {
        private IAccountOperation accountOperations = new AccountOperation();
        private IVerifyOperation operationVerify = new VerifyOperation();

        public Tuple<Operation, Account> depositOperation(Account account, double amount)
        {
            var operation = new Operation { operationType = OperationType.Deposit, date = DateTime.Now, amount = amount, balance = account.balance };
            account = accountOperations.Deposit(account, amount);
            account = accountOperations.AddOperation(account,operation);

            return Tuple.Create(operation,account);
        }

        public Tuple<Operation,List<Operation>> seeOperations(Account account)
        {
            var operation = new Operation { operationType = OperationType.Consult, date = DateTime.Now, amount = 0, balance = account.balance };
            account = accountOperations.AddOperation(account, operation);

            return Tuple.Create(operation,accountOperations.GetOperations(account));
        }

        public Tuple<Operation, Account> withdrawOperation(Account account, double amount)
        {
            if (!this.operationVerify.canWithdraw(account, amount)) throw new AccountOutOfBalanceException();
            accountOperations.Withdraw(account, amount);
            var operation = new Operation { operationType = OperationType.Deposit, date = DateTime.Now, amount = amount, balance = account.balance };
            account.operations.Add(operation);

            return Tuple.Create(operation, account);
        }
    }
}
