using BankAccount.Core.Model.Accounts;
using BankAccount.Persistency.Adapters;

namespace BankAccount.Persistency
{
    public class AccountAdapter : ObjectAdapter
    {
        public string username { get; set; }
        public string password { get; set; }
        public Account account { get; set; }

        public AccountAdapter() : base()
        {

        }
    }
}