using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount.Persistency.Memory;
using BankAccount.Persistency.Adapters.Adapter;
using BankAccount.Core;
using System.Runtime;
using BankAccount.Core.Model.Accounts;

namespace BankAccount.Persistency.Tests
{
    [TestClass]
    public class BankAccountMemoryPersistencyTests
    {
        private IPersistency<Adapter,int> memory;

        [TestInitialize]
        public void initialize()
        {
            this.memory = new MemoryPersistency();

            this.memory.addObject(new AccountAdapter
            {
                username = "John",
                password = "000",
                account = new Account
                {
                    firstName = "John",
                    lastname = "Doe",
                    balance = 0,
                    createdAt = System.DateTime.Now,
                    modifiedAt = System.DateTime.Now
                }
            });

        }

        [TestMethod]
        public void create_account_should_add_account_to_memory_with_id()
        {
        var account = new Account {
            firstName = "Jane",
            lastname = "Doe",
            balance = 20,
            createdAt = System.DateTime.Now,
            modifiedAt = System.DateTime.Now
        };
            var adapter = new AccountAdapter { username = "Jane", password = "0000", account = account };
            this.memory.addObject(adapter);
            Assert.IsTrue(this.memory.getObjects().Values.Contains(adapter));
        }

        [TestMethod]
        public void get_account_by_id_should_return_correct_account()
        {

        }

        
    }
}
