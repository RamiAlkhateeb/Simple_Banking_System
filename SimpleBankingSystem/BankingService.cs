using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingSystem
{
    public class BankingService : IBankingService
    {
        static readonly object _object = new object();
        public double[] _accounts;

        public BankingService(double[] accounts)
        {
            _accounts= accounts;

        }

        public void Deposit(int accountId, double amount)
        {
            if (accountId >= 0 && accountId < _accounts.Length && amount > 0) 
            {
                lock (_object)
                {
                    _accounts[accountId] += amount;
                }
            }
            else
                throw new ArgumentException();

        }

        public double GetBalance(int accountId)
        {
            if (accountId >= 0 && accountId < _accounts.Length)
            {
                return _accounts[accountId];
            }else
                throw new ArgumentException();
        }

        public void Withdraw(int accountId, double amount)
        {
            if (accountId >= 0 && amount > 0)
            {
                if(accountId < _accounts.Length)
                {
                    if(_accounts[accountId] - amount < 0)
                        throw new ArgumentException();
                    lock (_object)
                    {
                        _accounts[accountId] -= amount;
                    }
                }
                else
                    throw new ArgumentException();
            }
            else
                throw new ArgumentException();
        }
    }
}
