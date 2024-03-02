using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public interface InterfaceBankingSystem
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string userId { get; set; }

        public void AddMoney(double amount);
        public void Withdraw(double amount);
        public void CheckBalance();
    }
}
