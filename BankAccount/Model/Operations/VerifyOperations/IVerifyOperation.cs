using BankAccount.Core.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Core.Model.OperationsVerify
{
    internal interface IVerifyOperation
    {
        Boolean canWithdraw(Account account, double amount);
    }
}
