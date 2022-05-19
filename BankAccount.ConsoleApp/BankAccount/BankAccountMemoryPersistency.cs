using BankAccount.Persistency.Memory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Persistency.Memory.BankAccount
{
    public class BankAccountMemoryPersistency<AccountAdapter> : MemoryPersistency<AccountAdapter,int>
    {
        private int index;

        public BankAccountMemoryPersistency(IDictionary<int,AccountAdapter> dictionary) : base(dictionary)
        {
            index = 0;
        }
        public int createBankAccount(AccountAdapter account)
        {
            var id = index;
            index++;
           return base.addObject(account,id);
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
            return base.updateObject(id, adapter);
        }
    }
}
