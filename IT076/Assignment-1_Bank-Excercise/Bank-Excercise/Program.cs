using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Bank_Excercise
{
    public class HDFC : IBank
    {
        public string name;
        public int id;
        private int balance;

        public HDFC(string name, int id, int amt)
        {
            this.name = name;
            this.id = id;
            this.balance = amt;
        }

        public int deposit(int amt)
        {
            if (amt > 0)
            {
                balance += amt;
                return balance;
            }
            else
            {
                Console.WriteLine("Deposit amount should be greater than zero.");
                return balance;
            }
        }

        public int checkBalance()
        {
            return balance;
        }

        public int withdraw(int amt)
        {
            if (amt > 0)
            {
                if (amt <= balance)
                {
                    balance -= amt;
                    return balance;
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                    return balance;
                }
            }
            else
            {
                Console.WriteLine("Withdrawal amount should be greater than zero.");
                return balance;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<HDFC> list = new List<HDFC>()
            {
                new HDFC("Akshay", 10, 250000),
                new HDFC("Hemanth", 15, 500000),
                new HDFC("Dattatreya", 25, 750000),
                new HDFC("Kanaad", 50, 70000),
                new HDFC("Akash", 100, 850000),
            };

            foreach (HDFC hd in list)
            {
                Console.WriteLine(hd.name + " " + hd.id + " " + hd.checkBalance());
            }

            while (true)
            {
                Console.Write("\nEnter id: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid id. Please enter a numeric value.");
                    continue;
                }

                HDFC selectedAccount = list.Find(account => account.id == id);

                if (selectedAccount == null)
                {
                    Console.WriteLine("Account not found. Please enter a valid id.");
                    continue;
                }

                Console.WriteLine("Press 1 to deposit \nPress 2 to check balance \nPress 3 to withdraw money \nPress 4 to exit");
                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please enter a numeric value.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.Write("Enter the amount to be deposited: ");
                        int depositAmount;

                        if (!int.TryParse(Console.ReadLine(), out depositAmount))
                        {
                            Console.WriteLine("Invalid amount. Please enter a numeric value.");
                            continue;
                        }

                        selectedAccount.deposit(depositAmount);
                        Console.WriteLine($"Hi {selectedAccount.name}, your balance is: {selectedAccount.checkBalance()}");
                        break;

                    case 2:
                        Console.WriteLine($"Hi {selectedAccount.name}, your balance is: {selectedAccount.checkBalance()}");
                        break;

                    case 3:
                        Console.Write("Enter the amount to be withdrawn: ");
                        int withdrawAmount;

                        if (!int.TryParse(Console.ReadLine(), out withdrawAmount))
                        {
                            Console.WriteLine("Invalid amount. Please enter a numeric value.");
                            continue;
                        }

                        selectedAccount.withdraw(withdrawAmount);

                        Console.WriteLine($"Hi {selectedAccount.name}, your balance is: {selectedAccount.checkBalance()}");
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}