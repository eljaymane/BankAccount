using BankAccount.Persistency.Adapters.Adapter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Persistency.Memory
{
    public class MemoryPersistency : IPersistency<Adapter, int>
    {
        private Dictionary<int, Adapter> objectsMap;
        private int index;

        public MemoryPersistency()
        {
            objectsMap = new Dictionary<int, Adapter>();
            index = 0;
        }

        public void addObject(Adapter adapter)
        {
            this.objectsMap.Add(this.index, adapter);
            index++;
        }

        public IDictionary<int, Adapter> getObjects()
        {
            return objectsMap;
        }
    }
}
