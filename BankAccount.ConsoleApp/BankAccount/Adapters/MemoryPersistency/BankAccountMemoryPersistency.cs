using BankAccount.Persistency.Memory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.ConsoleApp.BankAccount.Adapters.MemoryPersistency
{
    public class BankAccountMemoryPersistency<AccountAdapter> : MemoryPersistency<AccountAdapter, int>
    {
        private int index;

        public BankAccountMemoryPersistency(IDictionary<int, AccountAdapter> dictionary) : base(dictionary)
        {
            index = 0;
            ObjectAdded += OnObjectAdded;
        }

        public void OnObjectAdded(object source, EventArgs e)
        {
            index++;
        }
        public int createBankAccount(AccountAdapter account)
        {
            var id = index;
            return base.addObject(account, id);
        }
        public AccountAdapter removeBankAccount(int id)
        {
            return base.deleteObject(id);
        }

        public AccountAdapter getBankAccount(int id)
        {
            return base.getObjectById(id);
        }

        public IDictionary<int, AccountAdapter> getBankAccounts()
        {
            return base.getObjects();
        }

        public AccountAdapter updateBankAccount(int id, AccountAdapter adapter)
        {
            return updateObject(id, adapter);
        }


    }
}
