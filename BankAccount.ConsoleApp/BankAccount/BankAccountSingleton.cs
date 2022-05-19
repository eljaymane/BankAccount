using BankAccount.Core;
using BankAccount.Core.Model.Accounts;
using BankAccount.Core.Model.Operations;
using BankAccount.Core.Model.OperationsAction;
using BankAccount.Core.Ports;
using BankAccount.Persistency.Memory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Persistency.Memory.BankAccount
{
    public class BankAccountSingleton : MemoryPersistencySingleton<AccountAdapter, int>
    {
        private ActionOperation actionOperation;
        private BankAccountMemoryPersistency<AccountAdapter> memory;
        public BankAccountSingleton(BankAccountMemoryPersistency<AccountAdapter> instance) : base(instance)
        {
            actionOperation = new ActionOperation();
            memory = ((BankAccountMemoryPersistency<AccountAdapter>)base.instance);
        }

        public AccountAdapter depositToBankAccount(AccountAdapter adapter,double amount)
        {
            try
            {
                adapter.account = actionOperation.depositOperation(adapter.account, 10).Item2;
                memory.updateBankAccount(adapter.id, adapter);
                return adapter;
            }catch(Exception e)
            {
                return null;

            }
            

        }

        public AccountAdapter withdrawFromBankAccount(AccountAdapter adapter, double amount)
        {
            try
            {
                adapter.account = actionOperation.withdrawOperation(adapter.account, 10).Item2;
                memory.updateBankAccount(adapter.id, adapter);
                return adapter;
            }
            catch (Exception e)
            {
                return null;

            }


        }
        public List<Operation> getOperationsOfBankAccount(AccountAdapter adapter)
        {
            try
            {
                return actionOperation.seeOperations(adapter.account).Item2;
            }catch(Exception e)
            {
                return null;
            }
           

        }

    }
}
