using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankCustomerExample;
namespace BankCustomerExample
{

    public interface CustomerDeclaration
    {
        public int deposit(int addMoney);
        public int withdraw(int removeMoney);
        public int getBalance(int balance);
    }
}
