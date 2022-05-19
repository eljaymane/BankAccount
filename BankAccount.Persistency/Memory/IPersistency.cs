using BankAccount.Persistency.Adapters.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Persistency.Memory
{
    public interface IPersistency<T,ID> where T : Adapter
    {
        void addObject(T adapter);
        IDictionary<ID,T> getObjects();
    }
}
