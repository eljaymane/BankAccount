using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Persistency.Disk.Core
{
    public abstract class Parser<TSource,TTarget> : ISerializer<TSource,TTarget> 
    {

        public abstract Type AcceptsType { get; }
        public abstract Type ReturnsType { get; }
        public abstract Task<TSource> deserialize(TTarget target);
        public abstract Task<TTarget> serialize(TSource source);
       
    }
}
