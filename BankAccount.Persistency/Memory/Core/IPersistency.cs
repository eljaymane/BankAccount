
namespace BankAccount.Persistency.Memory.Core
{
    public interface IPersistency<T1, T2, ID>
    {
        ID addObject(T1 adapter, ID id);
        T1 getObjectById(ID id);
        T1 updateObject(ID id, T1 adapter);
        T2 getObjects();
        T1 deleteObject(ID id);
    }
}
