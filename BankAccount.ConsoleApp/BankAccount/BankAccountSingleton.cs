using BankAccount.ConsoleApp;
using BankAccount.ConsoleApp.BankAccount.Adapters.MemoryPersistency;
using BankAccount.ConsoleApp.BankAccount.Exceptions;
using BankAccount.Core;
using BankAccount.Core.Exceptions;
using BankAccount.Core.Model.Accounts;
using BankAccount.Core.Model.Operations;
using BankAccount.Core.Model.OperationsAction;
using BankAccount.Core.Model.OperationsAction.Exceptions;
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
        private int index;
        private ActionOperation actionOperation;
        public BankAccountMemoryPersistency<AccountAdapter> memory;
        public AccountAdapter? loggedAccount { get; set; }
        public bool quit = false;
        public bool isLogged = false;
        public BankAccountSingleton(BankAccountMemoryPersistency<AccountAdapter> instance) : base(instance)
        {
            actionOperation = new ActionOperation();
            memory = ((BankAccountMemoryPersistency<AccountAdapter>)base.instance);
            index = 0;
            base.instance.ObjectAdded += OnObjectAdded;
        }

        public void OnObjectAdded(object source, EventArgs e)
        {
            index++;
        }
        public int createBankAccount(AccountAdapter account)
        {
            var id = index;
            if (!(base.instance.getObjects().Values.Where(e => e.username == account.username).Count().Equals(0))) throw new UsernameAlreadyInUseException();
            return base.instance.addObject(account, id);
        }
        public AccountAdapter removeBankAccount(int id)
        {
            return base.instance.deleteObject(id);
        }

        public AccountAdapter getBankAccount(int id)
        {
            return base.instance.getObjectById(id);
        }

        public IDictionary<int, AccountAdapter> getBankAccounts()
        {
            return base.instance.getObjects();
        }

        public AccountAdapter updateBankAccount(int id, AccountAdapter adapter)
        {
            return base.instance.updateObject(id, adapter);
        }

        public AccountAdapter depositToBankAccount(AccountAdapter adapter,double amount)
        {
            try
            {
                adapter.account = actionOperation.depositOperation(adapter.account, amount).Item2;
                this.updateBankAccount(adapter.id, adapter);
                return adapter;
            }catch(Exception e)
            {
                throw new CouldNotDepositException();

            }
            

        }

        public AccountAdapter withdrawFromBankAccount(AccountAdapter adapter, double amount)
        {
            try
            {
                adapter.account = actionOperation.withdrawOperation(adapter.account, amount).Item2;
                this.updateBankAccount(adapter.id, adapter);
                return adapter;
            }
            catch (Exception e)
            {
                throw new CouldNotWithdrawException();

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

        public AccountAdapter login(string username,string password)
        {
            AccountAdapter adapter;
            adapter = this.getBankAccounts().Where(e => e.Value.username == username && e.Value.password == password).FirstOrDefault().Value;
            if (adapter != null)
            {
                this.loggedAccount = adapter;
                this.isLogged = true;
            }
            return adapter;

        }
        

    }
}
