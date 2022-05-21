using BankAccount.Persistency.Disk.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Persistency.Disk
{
    public interface IDiskPersistency<TParser,TSource,TTarget> where TParser : ISerializer<TSource,TTarget>
    {
        Task<TTarget> persistToDisk(TSource source);
        Task<TSource> getFromDisk(TTarget path);
    }
}
