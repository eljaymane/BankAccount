using BankAccount.Persistency.Adapters.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Persistency.Memory.Core
{
    public abstract class MemoryPersistencySingleton<T,ID> where T : ObjectAdapter
    {
        protected MemoryPersistency<T, ID> instance { get; }

        public MemoryPersistencySingleton(MemoryPersistency<T, ID> instance)
        {
            this.instance = instance;
        }
    }
}
