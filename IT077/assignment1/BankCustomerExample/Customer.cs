using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankCustomerExample;
namespace BankCustomerExample
{

    public class Customer : CustomerDeclaration
    {
        string customerName;
        int balance;
        long accountNumber;
        int addMoney;
        int removeMoney;
      
        public Customer(string customerName,int balance)
        {
          this.customerName = customerName;
          this.balance = balance;

        }
        public void getCustomerDetails(string customerName, long accountNumber)
        {
            Console.WriteLine("The Name of the Customer is:" + customerName);
            Console.WriteLine("The AccountNumber of the customer is:" + accountNumber);
        }
        public int deposit(int addMoney)
        {
            return balance + addMoney;
        }
        public int withdraw(int removeMoney)
        {
            if (balance == 0)
            {
                Console.WriteLine("The blance is zero you can't withdraw the money");
                return balance;
            }
            if (balance < removeMoney)
            {
                Console.WriteLine("You can't withdraw balance is" + balance);
                return balance;
            }
            return balance - removeMoney;
        }
        public int getBalance(int balance)
        {
            return balance;
        }

    }
}