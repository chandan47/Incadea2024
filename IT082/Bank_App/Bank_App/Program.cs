using Bank_App;
using System.Linq;
using System;

public class MyBank
{
    static void Main(string[] args)
    {
        Bank myaccount = new bankAccount();
        Console.WriteLine("WELCOME TO BANK");
        Console.WriteLine("Enter Your Customer ID");
        myaccount.CustId = Convert.ToDouble(Console.ReadLine());
        //myaccount.balance = 0;
        myaccount.DisplayDetails(myaccount.CustId);

        while (true)
        {
            Console.WriteLine("Enter your Choice.");
            Console.WriteLine("\n 1.Deposit Money \n 2.Withdraw Money \n 3.Check Balance \n 4.Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter the ammount to be deposited");
                int Creditmoney = Convert.ToInt32(Console.ReadLine());
                myaccount.DepositMoney(Creditmoney);
                //continue;
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter the amount you want to withdraw");
                int debitMoney = Convert.ToInt32(Console.ReadLine());
                if (myaccount.balance >= debitMoney)
                {
                    myaccount.WithdrawMoney(debitMoney);
                }
                else
                {
                    Console.WriteLine("INSUFFICIENT BALANCE !!!");
                }
            }
            else if (choice == 3)
            {
                myaccount.CheckBalance();
            }
            else
            {
                break;
            }
        }
    }

}
