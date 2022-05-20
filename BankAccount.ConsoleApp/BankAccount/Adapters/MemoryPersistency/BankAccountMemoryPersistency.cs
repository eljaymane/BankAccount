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
        

        public BankAccountMemoryPersistency(IDictionary<int, AccountAdapter> dictionary) : base(dictionary)
        {
            
        }

        
        


    }
}
