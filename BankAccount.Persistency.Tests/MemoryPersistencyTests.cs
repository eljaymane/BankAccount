using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount.Persistency.Memory;
using BankAccount.Persistency.Adapters.Adapter;
using BankAccount.Core;
using System.Runtime;
using BankAccount.Core.Model.Accounts;
using BankAccount.Persistency.Adapters.Account.Exceptions;
using BankAccount.Persistency.Memory.Exceptions;
using BankAccount.Persistency.Memory.Core;
using System.Collections.Generic;

namespace BankAccount.Persistency.Tests
{
    [TestClass]
    public class MemoryPersistencyTests
    {
        private MemoryPersistency<Adapter,int> memory;

        [TestInitialize]
        public void initialize()
        {
            this.memory = new MemoryPersistency<Adapter,int>(new Dictionary<int,Adapter>());
            this.memory.addObject(new Adapter{ id = 0}, 0) ;

        }

        [TestMethod]
        public void create_object_should_add_object_to_memory_with_id()
        {

            var adapter = new Adapter { id=1 };
            var id = this.memory.addObject(adapter,adapter.id);
            Assert.IsTrue(this.memory.getObjects().Values.Contains(adapter));
            Assert.IsTrue(this.memory.getObjects().Keys.Contains(id));
        }

        [TestMethod]
        public void get_object_by_id_should_return_correct_object()
        {
            var adapter = (Adapter)this.memory.getObjectById(0);
            Assert.AreEqual(adapter.id, 0);

        }

        [TestMethod]
        [ExpectedException(typeof(ObjectNotFoundException))]
        public void get_unexistent_object_should_raise_exception()
        {
            this.memory.getObjectById(100000);
        }


    }
}
