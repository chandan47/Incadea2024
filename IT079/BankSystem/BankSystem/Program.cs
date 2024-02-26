using BankingSystem;
using System.Security.Principal;

public class BankAccount : InterfaceBankingSystem
{
    public string Name { get; set; }
    public double Balance { get; set; }
    public string userId { get; set; }

    public void AddMoney(double amount)
    {
        Balance += amount;
        Console.WriteLine($"Rs. {amount} is added to {Name}'s account.\nNew balance: Rs. {Balance}\n");
    }

    public void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Rs. {amount} is withdrawn from {Name}'s account.\nNew balance: Rs. {Balance}\n");
        }
        else
        {
            Console.WriteLine($"Insufficient Balance in {Name}'s account. Withdrawal failed.\n");
        }
    }

    public void CheckBalance()
    {
        Console.WriteLine($"{Name}'s account balance: Rs. {Balance}\n");
    }

    public static void Main()
    {
        Dictionary<string, InterfaceBankingSystem> myDict = new Dictionary<string, InterfaceBankingSystem>();
        //List<dynamic> userList = new List<dynamic>();
        //myDict.Add("rakshit123", userList.Add("Rakshit Halijol", 2000.00));
        //List<dynamic> userDetails = new List<dynamic>();
        InterfaceBankingSystem myAccount = new BankAccount();

        Console.WriteLine("***     Hii, Welcome to MyBank...!!!     ***\n\n");
        Console.WriteLine("New Registration?\n0. No\n1. Yes\n\n");
        int registerChoice = Convert.ToInt32(Console.ReadLine());
        if (registerChoice == 0)
        {
            Console.WriteLine("Enter UserID:");
            string takeUserId = Console.ReadLine();


        }
        else
        {
            Console.WriteLine("Enter Details for Registration: \n");
            Console.WriteLine("Enter New UserID of Your Choice:");
            myAccount.userId = Console.ReadLine();
            Console.WriteLine("Enter Your Name:");
            myAccount.Name = Console.ReadLine();
            Console.WriteLine("Enter Your Account Balance:");
            myAccount.Balance = Convert.ToDouble(Console.ReadLine());

        }

        while (true)
        {
            Console.WriteLine("\n\n1. Add Money\n2. Withdrawl\n3. Check Balance\n4. Exit\n\n");
            Console.WriteLine("Enter Your Choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter how much amount need to be added:");
                double amtToAdd = Convert.ToDouble(Console.ReadLine());
                myAccount.AddMoney(amtToAdd);
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter how much amount need to be withdraw:");
                double amtWithdraw = Convert.ToDouble(Console.ReadLine());
                myAccount.Withdraw(amtWithdraw);
            }
            else if (choice == 3)
            {
                myAccount.CheckBalance();
            }
            else
            {
                myAccount.CheckBalance();
                Console.WriteLine("You're Terminated Now\n\nThank You\n\n");
                break;
            }
        }
    }
}