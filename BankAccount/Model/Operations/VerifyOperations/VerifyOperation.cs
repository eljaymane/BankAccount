using BankAccount.Core.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Core.Model.OperationsVerify
{
    internal class VerifyOperation : IVerifyOperation
    {
        public bool canWithdraw(Account account, double amount)
        {
            if (account.balance < amount) return false;
            return true;
        }
    }
}
