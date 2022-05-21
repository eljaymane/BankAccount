using BankAccount.Persistency.Disk.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Persistency.Disk
{
    internal interface IDiskPersistency<TParser,TSource,TTarget> where TParser : ISerializer<TSource,TTarget>
    {
        TTarget persistToDisk(TSource source);
        TSource getFromDisk(TTarget path);
    }
}
