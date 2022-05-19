using BankAccount.Persistency.Adapters.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Persistency.Memory.Core
{
    public interface IPersistency<T, ID>
    {
        ID addObject(T adapter, ID id);
        T getObjectById(ID id);
        IDictionary<ID, T> getObjects();
        T updateObject(ID id, T adapter);
        T deleteObject(ID id);
    }
}
