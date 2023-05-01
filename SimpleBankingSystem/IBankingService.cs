using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingSystem
{
    public interface IBankingService
    {
        double GetBalance(int accountId);
        void Withdraw(int accountId, double amount);
        void Deposit(int accountId, double amount);

    }
}
