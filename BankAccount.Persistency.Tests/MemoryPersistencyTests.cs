using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount.Persistency.Disk;
using BankAccount.Persistency.Memory.Exceptions;
using BankAccount.Persistency.Memory.Core;
using System.Collections.Generic;
using BankAccount.Persistency.Disk.Core;
using BankAccount.Persistency.Disk.Serializers.XmlParser;
using System;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using Moq;
using System.IO;
using BankAccount.Persistency.Adapters;

namespace BankAccount.Persistency.Tests
{
    [TestClass]
    public class MemoryPersistencyTests
    {
        private MemoryPersistency<ObjectAdapter,int> memory;

        [TestInitialize]
        public void initialize()
        {
            this.memory = new MemoryPersistency<ObjectAdapter,int>(new Dictionary<int,ObjectAdapter>());
            this.memory.addObject(new ObjectAdapter{ id = 0}, 0) ;

        }

        [TestMethod]
        public void create_object_should_add_object_to_memory_with_id()
        {

            var adapter = new ObjectAdapter { id=1 };
            var id = this.memory.addObject(adapter,adapter.id);
            Assert.IsTrue(this.memory.getObjects().Values.Contains(adapter));
            Assert.IsTrue(this.memory.getObjects().Keys.Contains(id));
        }

        [TestMethod]
        public void get_object_by_id_should_return_correct_object()
        {
            var adapter = this.memory.getObjectById(0);
            Assert.AreEqual(adapter.id, 0);

        }

        [TestMethod]
        [ExpectedException(typeof(ObjectNotFoundException))]
        public void get_unexistent_object_should_raise_exception()
        {
            this.memory.getObjectById(100000);
        }

        [TestMethod]
        public void disposing_memory_persistency_should_empty_memory_and_trigger_disk_persistency_if_activated()
        {
            var path = Environment.CurrentDirectory + "/";
            var diskPersistency = new DiskPersistency<XmlParser<List<ObjectAdapter>>, List<ObjectAdapter>, string>(new XmlParser<List<ObjectAdapter>>(path));
            this.memory = new MemoryPersistency<ObjectAdapter, int>(new Dictionary<int,ObjectAdapter>(), diskPersistency);
            var objectAdapter = new ObjectAdapter() { id = 1};
            using (this.memory)
            {
                this.memory.addObject(objectAdapter, objectAdapter.id);
            }
            var test = path + typeof(ObjectAdapter).Name + ".xml";
            Assert.IsTrue(File.Exists(test));
            Assert.IsTrue(this.memory.getObjects().Count == 0);
            
        }


    }
}
