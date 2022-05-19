using BankAccount.Persistency.Adapters.Adapter;
using BankAccount.Core.Model.Accounts;

namespace BankAccount.Persistency
{
    public class AccountAdapter : Adapter
    {
        public string username { get; set; }
        public string password { get; set; }
        public Account account { get; set; }
    }
}