// See https://aka.ms/new-console-template for more information
using BankCustomerExample;
int n;
int balance = 0;
string name;
long accountNo;
long accountNumber;
long withDrawAccountNumber;
long balanceAccountNumber;
Dictionary<long, Customer> users= new Dictionary<long,Customer>();

do
{
    Console.WriteLine("\n\nThe Operations To Be Performed");
    Console.WriteLine("1.Create account");
    Console.WriteLine("2.Deposit Money");
    Console.WriteLine("3.Withdraw Money");
    Console.WriteLine("4.Check Balance");
    Console.WriteLine("5.Exit");
    Console.WriteLine("Choose one among the above operations");
    n = Convert.ToInt32(Console.ReadLine());
    switch (n)
    {
        case 1:
            Console.Write("Enter Account holder name");
            name= Console.ReadLine();
            Console.WriteLine("Enter the Account Number");
            accountNo= Convert.ToInt64(Console.ReadLine());
            if (!users.ContainsKey(accountNo))
            {
                Console.WriteLine("Enter the initial balance");
                balance = Convert.ToInt32(Console.ReadLine());
                users.Add(accountNo, new Customer(name, balance));
                Console.WriteLine("Account created successfully create another account by clicking one");
            }
            else
                Console.WriteLine("Account already Exists");
            break;
        case 2:Console.WriteLine("Enter the account number");
            accountNumber= Convert.ToInt64(Console.ReadLine());
            if (users.ContainsKey(accountNumber))
            {
                Console.WriteLine("Enter the amount to deposit");
                int depositMoney = Convert.ToInt32(Console.ReadLine());
                balance = users[accountNumber].deposit(depositMoney);
            }
            else
                Console.WriteLine("Account Not Found");
                break;
           
        case 3:Console.WriteLine("Enter Account Number");
               withDrawAccountNumber = Convert.ToInt64(Console.ReadLine());
            if (users.ContainsKey(withDrawAccountNumber))
            {
                Console.WriteLine("Enter the money to Withdraw");
                int withDrawMoney = Convert.ToInt32(Console.ReadLine());
                balance = users[withDrawAccountNumber].withdraw(withDrawMoney);
            }
            else
            {
                Console.WriteLine("Account Not Found");
            }
            break;
        case 4:
            Console.WriteLine("Enter the AccountNumber");
            balanceAccountNumber = Convert.ToInt32(Console.ReadLine());
            if (users.ContainsKey(balanceAccountNumber))
            {
                balance = users[balanceAccountNumber].getBalance(balance);
                Console.WriteLine("The balance is:" + balance);
            }
            else
                Console.WriteLine("Account Not found");
            break;
        default:Environment.Exit(0);
            break;
       

    }
} while (n != 5);

