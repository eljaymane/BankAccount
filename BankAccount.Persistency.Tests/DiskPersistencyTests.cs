using BankAccount.Persistency.Disk.Core;
using BankAccount.Persistency.Disk.Serializers.XmlParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Persistency.Tests
{
    [TestClass]
    public class DiskPersistencyTests
    {
        DiskPersistency<XmlParser<TestObject>, TestObject, string> diskPersistency;
        TestObject o; 

        [TestInitialize]
        public void initialize()
        {
            diskPersistency = new DiskPersistency<XmlParser<TestObject>, TestObject, string>(new XmlParser<TestObject>(Environment.CurrentDirectory));
            o = new TestObject() { one = "one", two = 2 };
        }

        [TestMethod]
        public async Task persisting_object_to_disk_creates_file()
        {
            var path = await this.diskPersistency.persistToDisk(o);
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public async Task reading_file_recreates_object()
        {
            var path = await this.diskPersistency.persistToDisk(o);
            TestObject result = await this.diskPersistency.getFromDisk(path);
            Assert.AreEqual(result.one, o.one);
            Assert.AreEqual(result.two, o.two);

        }


    }
}
public class TestObject
{
    public string one {get; set;}
    public int two { get; set; }
}
