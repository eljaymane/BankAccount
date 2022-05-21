using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Persistency.Disk.Core
{
    public interface ISerializer<TSource,TTarget>
    {
        TTarget serialize(TSource soruce);
        TSource deserialize(TTarget target);
    }
}
