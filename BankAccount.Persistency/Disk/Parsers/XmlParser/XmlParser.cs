using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BankAccount.Persistency.Disk.Core;

namespace BankAccount.Persistency.Disk.Serializers.XmlParser
{
    public class XmlParser<TSource> : Parser<TSource, String>
    {

        public XmlParser(string pathToDisk)
        {
            this.pathToDisk = pathToDisk;
        }

        public string pathToDisk { get; set; }

        public override Type AcceptsType => typeof(TSource);

        public override Type ReturnsType => typeof(string);

        public override async Task<TSource> deserialize(String target)
        {
            XmlSerializer s = new XmlSerializer(typeof(TSource));
            using (var _reader = new FileStream(target.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                TSource result = (TSource)s.Deserialize(_reader);
            return result;
            }
            

        }
        public override async Task<String> serialize(TSource source) {
  
            XmlSerializer _serializer = new XmlSerializer(typeof(TSource));
            var target = typeof(TSource).IsGenericType? await getFileNameFromType(typeof(TSource)) : typeof(TSource).Name + ".xml";
   
            using (var _writer = new StreamWriter(target)){

                _serializer.Serialize(_writer, source);
                

                return target;
            }
        }

        private async Task<String> getFileNameFromType(Type type)
        {
            if (type.GetGenericTypeDefinition() != typeof(List<>)) return type.Name + ".xml";
            var fileName = type.GetGenericArguments()[0].Name + ".xml";
            fileName = fileName.Split('.')[fileName.Split('.').Length - 2].Replace("]", String.Empty);
            fileName += ".xml";
            return fileName;

        }
    }
}
