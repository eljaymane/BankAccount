using BankAccount.ConsoleApp.BankAccount.Adapters.MemoryPersistency;
using BankAccount.ConsoleApp.BankAccount.Exceptions;
using BankAccount.Core.Exceptions;
using BankAccount.Core.Model.Accounts;
using BankAccount.Core.Model.Operations;
using BankAccount.Persistency;
using BankAccount.Persistency.Disk.Core;
using BankAccount.Persistency.Disk.Serializers.XmlParser;
using BankAccount.Persistency.Memory.BankAccount;
using System.Reflection;
using System.Runtime.Remoting;

public class program 
{
    private static BankAccountSingleton bankAccountApp = new BankAccountSingleton(new BankAccountMemoryPersistency<AccountAdapter>(new Dictionary<int, AccountAdapter>(), new DiskPersistency<XmlParser<List<AccountAdapter>>,List<AccountAdapter>,string>(new XmlParser<List<AccountAdapter>>(Environment.CurrentDirectory))));
    
    private static string response;

     async static Task Main()
    {
        do
        {
            if (bankAccountApp.isLogged == false) response = writeWelcomeMessage();
            else
            {
                response =  writeActionsMessage();
            }
            
            
            await responseHandler(response, bankAccountApp);
        } while (!bankAccountApp.quit);
    }

    static string writeWelcomeMessage()
    {
        Console.WriteLine("Welcome to the banking app.");
        Console.WriteLine("Create an account (Create)\n Login to your account (Login)");
        return Console.ReadLine().ToLower();
    }

    static string writeActionsMessage()
    {
        Console.WriteLine("Deposit funds (Deposit)\n Withdraw funds (Withdraw)\n See Operations (Operations)\n Logout (Logout)");
        return Console.ReadLine().ToLower();
    }

    async static Task<Object> createObjectByReflection(Type targetType)
    {

        dynamic _object = Activator.CreateInstance(targetType);
        foreach (PropertyInfo prop in targetType.GetProperties())
        {
            bool isId = prop.Name.ToLower() == "id";
            bool isDateTime = prop.PropertyType == (typeof(DateTime));
            bool isList = prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
            bool isPrimitiveType = prop.PropertyType.IsPrimitive || prop.PropertyType.IsValueType || prop.PropertyType == typeof(string);   

            if (isId || isDateTime || isList) continue;
            if (!isPrimitiveType)
            {
                _object.GetType().GetProperty(prop.Name).SetValue(_object, await createObjectByReflection(prop.PropertyType));
            } 
            else
            {
                Console.WriteLine(prop.Name + " ? : ");
                var input = Console.ReadLine();
                if (prop.PropertyType != typeof(string))
                {
                    if (prop.PropertyType == typeof(int))
                    {
                        _object.GetType().GetProperty(prop.Name).SetValue(_object, int.Parse(input));
                    }
                    if (prop.PropertyType == typeof(double))
                    {
                        _object.GetType().GetProperty(prop.Name).SetValue(_object, double.Parse(input.Replace(".", ",")));
                    }

                }
                else
                {
                    _object.GetType().GetProperty(prop.Name).SetValue(_object, input);
                }
            }
            

        }

        return _object;

    }

    async static Task responseHandler(string response, BankAccountSingleton bankAccountApp)
    {
        switch (response)
        {
            case "q":
                bankAccountApp.quit = true;
                break;
            case "create":
                try
                {
                    bankAccountApp.createBankAccount((AccountAdapter)await createObjectByReflection(typeof(AccountAdapter)));
                }catch(UsernameAlreadyInUseException e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
                
                break;
            case "login":
                await login(bankAccountApp);
                break;
            case "deposit":
                await deposit(bankAccountApp);
                break;
            case "logout":
                bankAccountApp.loggedAccount = null;
                bankAccountApp.isLogged = false;
                break;
            case "withdraw":
                await withdraw(bankAccountApp);
                
                break;
            case "operations":
                await seeOperations(bankAccountApp);
                break;
            default:
                break;

        }
    }

    async static Task seeOperations(BankAccountSingleton bankAccountApp)
    {
        var operations = bankAccountApp.getOperationsOfBankAccount(bankAccountApp.loggedAccount).OrderBy(e => e.date);
        foreach(Operation o in operations)
        {
            Console.WriteLine(o);
        }
        Console.WriteLine("Press a key to go to the main menu");
        Console.ReadLine();
    }

    async static Task<double> getActualBalance(BankAccountSingleton bankAccountApp)
    {
        return Math.Round(bankAccountApp.memory.getObjectById(bankAccountApp.loggedAccount.id).account.balance,2);
    }

    async static Task withdraw(BankAccountSingleton bankAccountApp)
    {
        Console.WriteLine("Amount to withdraw ?");
        try
        {
            bankAccountApp.withdrawFromBankAccount(bankAccountApp.loggedAccount, Double.Parse(Console.ReadLine().Replace(".", ",")));
            Console.WriteLine("Money withdrawn ! Here's your new balance {0}", await getActualBalance(bankAccountApp));
        }
        catch(CouldNotWithdrawException e)
        {
            Console.WriteLine(e.Message);
        }
       
       
    }

    async static Task deposit(BankAccountSingleton bankAccountApp)
    {
        Console.WriteLine("Amount to deposit ?");
        bankAccountApp.depositToBankAccount(bankAccountApp.loggedAccount, Double.Parse(Console.ReadLine().Replace(".", ",")));
        Console.WriteLine("Deposit done ! Here's your new balance {0}", await getActualBalance(bankAccountApp));
    }

    async static Task login(BankAccountSingleton app)
    {
        Console.WriteLine("username ? ");
        var username = Console.ReadLine();
        Console.WriteLine("password ? ");
        var password = Console.ReadLine();
        app.login(username, password);
    }


   
  


}