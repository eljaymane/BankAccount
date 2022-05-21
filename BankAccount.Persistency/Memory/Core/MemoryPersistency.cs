using BankAccount.Persistency.Adapters.Adapter;
using BankAccount.Persistency.Disk.Core;
using BankAccount.Persistency.Disk.Serializers.XmlParser;
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
        private DiskPersistency<Parser<IDictionary<ID,T>,string>, IDictionary<ID,T>, string>? diskPersistency;

        public MemoryPersistency(IDictionary<ID, T> objectsMap)
        {
            this.objectsMap = objectsMap;
           
        }

        public MemoryPersistency(IDictionary<ID, T> objectsMap, DiskPersistency<Parser<IDictionary<ID, T>, string>, IDictionary<ID, T>, string> diskPersistency)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            this.diskPersistency = diskPersistency;
            this.objectsMap = objectsMap;

        }
        private void OnProcessExit(object sender, EventArgs e)
        {
            this.diskPersistency.persistToDisk(this.objectsMap);
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
