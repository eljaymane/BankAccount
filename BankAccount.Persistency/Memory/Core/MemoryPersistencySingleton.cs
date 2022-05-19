using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Persistency.Memory.Core
{
    public abstract class MemoryPersistencySingleton<T,ID>
    {
        protected MemoryPersistency<T, ID> instance { get; }

        public MemoryPersistencySingleton(MemoryPersistency<T, ID> instance)
        {
            this.instance = instance;
        }
    }
}
