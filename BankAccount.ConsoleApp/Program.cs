using BankAccount.Persistency;
using BankAccount.Persistency.Memory.BankAccount;

BankAccountSingleton bankAccountApp = new BankAccountSingleton(new BankAccountMemoryPersistency<AccountAdapter>(new Dictionary<int,AccountAdapter>()));