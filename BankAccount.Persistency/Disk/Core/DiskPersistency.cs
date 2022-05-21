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


        public TTarget persistToDisk(TSource source)
        {
            return parser.serialize(source);
        }

        public TSource getFromDisk(TTarget path)
        {
            return parser.deserialize(path);
        }
    }
}
