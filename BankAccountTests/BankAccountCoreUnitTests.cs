
using BankAccount.Core.Model.Accounts;
using BankAccount.Core.Model.Operations;
using BankAccount.Core.Model.OperationsAction;
using BankAccount.Core.Model.OperationsAction.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BankAccount.Core.Tests
{
    [TestClass]
    public class BankAccountCoreUnitTests
    {
        private List<Account> accountsList;

        [TestInitialize]
        public void Initialize()
        {
             this.accountsList = new List<Account>{
                new Account { firstName = "John", lastname = "Doe", balance = 0, createdAt = System.DateTime.Now, modifiedAt = System.DateTime.Now},
                new Account { firstName = "Jane", lastname = "Smith", balance = 20, createdAt = System.DateTime.Now, modifiedAt = System.DateTime.Now },
                new Account { firstName = "Jean", lastname = "Dupont", balance = 100, createdAt = System.DateTime.Now, modifiedAt = System.DateTime.Now },
            };

            }

#region UserStory1

        [TestMethod]
        public void deposit_updates_account_balance()
        {
            var operationsAction = new ActionOperation();
            var account = this.accountsList.Find(a => a.lastname == "Doe");
            var amount = 10;
            var expected = account.balance + amount;
            account = operationsAction.depositOperation(account,amount).Item2;
            Assert.AreEqual(expected,account.balance);
        }

        [TestMethod]
        public void deposit_is_registred_in_account_operations()
        {
            var operationsAction = new ActionOperation();
            var account = this.accountsList.Find(a => a.lastname == "Doe");
            Tuple<Operation,Account> response = operationsAction.depositOperation(account, 0);
            Assert.IsTrue(response.Item2.operations.Contains(response.Item1));

        }
#endregion

#region UserStory2

        [TestMethod]
        public void withdrawal_updates_account_balance()
        {
            var operationsAction = new ActionOperation();
            var account = this.accountsList.Find(a => a.lastname == "Dupont");
            var amount = 10;
            var expected = account.balance - amount;
            account = operationsAction.withdrawOperation(account, amount).Item2;
            Assert.AreEqual(expected, account.balance);
        }

        [TestMethod]
        public void withdrawal_is_registred_in_account_operations()
        {
            var operationsAction = new ActionOperation();
            var account = this.accountsList.Find(a => a.lastname == "Doe");
            Tuple<Operation, Account> response = operationsAction.withdrawOperation(account, 0);
            Assert.IsTrue(response.Item2.operations.Contains(response.Item1));

        }

        [TestMethod]
        [ExpectedException(typeof(AccountOutOfBalanceException))]
        public void withdrawal_impossible_if_out_of_balance()
        {
            var operationsAction = new ActionOperation();
            var account = this.accountsList.Find(a => a.lastname == "Doe");
            var amount = 10;
            var expected = account.balance - amount;
            operationsAction.withdrawOperation(account, amount);  

        }
        #endregion

#region UserStory3

        [TestMethod]
        public void see_operations_should_return_all_operations()
        {
            var operationsAction = new ActionOperation();
            var account = this.accountsList.Find(a => a.lastname == "Smith");
            var amount = 10;
            var result1 = operationsAction.depositOperation(account,amount);
            var result2 = operationsAction.withdrawOperation(account, amount);
            Assert.IsTrue(operationsAction.seeOperations(result2.Item2).Item2.Contains(result1.Item1));
            Assert.IsTrue(operationsAction.seeOperations(result2.Item2).Item2.Contains(result2.Item1));
        }


    }
#endregion
}
