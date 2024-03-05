using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_App
{
    public class bankAccount : Bank
    {
        public string Name { get; set; }
        public double balance { get; set; }
        public double CustId { get; set; }

        public void DisplayDetails(Double CustId)
        {
            Console.WriteLine($"Customer ID :{CustId}");
            Console.WriteLine($"Name :{Name}");
            Console.WriteLine($"Bank Balance :{balance}");
        }



        public void DepositMoney(double amount)
        {
            balance = balance + amount;

        }
        public void WithdrawMoney(double amount)
        {
            balance = balance - amount;
        }
        public void CheckBalance()
        {
            Console.WriteLine($"The amount of {Name}'s account is {balance}");
        }
    }
}
