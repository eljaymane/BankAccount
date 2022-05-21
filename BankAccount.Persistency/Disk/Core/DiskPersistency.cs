using BankAccount.Persistency.Disk.Serializers.XmlParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankAccount.Persistency.Disk.Core
{
    public class DiskPersistency<TParser,TSource,TTarget> : IDiskPersistency<TParser,TSource,TTarget> where TParser : ISerializer<TSource,TTarget>
    {
        public TParser parser { get; set; }

        public DiskPersistency(TParser parser)
        {
            this.parser = parser;
        }


        public async Task<TTarget> persistToDisk(TSource source)
        {
            return await parser.serialize(source);
        }

        public async Task<TSource> getFromDisk(TTarget path)
        {
            return await parser.deserialize(path);
        }
    }
}
