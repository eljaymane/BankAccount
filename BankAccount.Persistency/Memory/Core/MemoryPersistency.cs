using BankAccount.Persistency.Adapters.Adapter;
using BankAccount.Persistency.Memory.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount.Persistency.Memory.Core
{
    public class MemoryPersistency<T, ID> : IPersistency<T, IDictionary<ID, T>, ID>
    {
        public event EventHandler ObjectAdded;
        private IDictionary<ID, T> objectsMap { get; set; }
        public MemoryPersistency(IDictionary<ID, T> objectsMap)
        {
            this.objectsMap = objectsMap;
           
        }

        protected virtual void OnObjectAdded()
        {
            if (ObjectAdded != null)
            {
                ObjectAdded(this, EventArgs.Empty);
            }
        }
  
        public virtual ID addObject(T entity, ID id)
        {
            objectsMap.Add(id, entity);
            OnObjectAdded();
            return id;
        }


        public virtual T deleteObject(ID id)
        {
            T result;
            if (!objectsMap.TryGetValue(id, out result)) throw new ObjectNotFoundException();
            objectsMap.Remove(id);
            return result;
        }

        public virtual T getObjectById(ID id)
        {
            T result;
            if (!objectsMap.TryGetValue(id, out result)) throw new ObjectNotFoundException();
            return result;
        }

        public virtual IDictionary<ID,T> getObjects()
        {
            return objectsMap;
        }

        public T updateObject(ID id, T adapter)
        {
            T result;
            if (!objectsMap.TryGetValue(id, out result)) throw new ObjectNotFoundException();
            objectsMap[id] = adapter;
            return objectsMap[id];
        }

    }
}
