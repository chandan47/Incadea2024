using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_App
{
    public interface Bank
    {
        public string Name { get; set; }
        public double balance { get; set; }
        public double CustId {  get; set; }

        public void DepositMoney(Double amount);
        public void WithdrawMoney(Double amount);
        public void CheckBalance();
        public void DisplayDetails(double CustId);
    }
}

