using SimpleBankingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class StressTests
    {
        private const double InitialAmount = 10_000_000.0;
        private const int Timeout = 1500;
        private static readonly Random Rnd = new Random(10);

        [Theory(DisplayName = "Should perform all operations concurrently")]
        [InlineData(5, 1000)]
        [InlineData(5, 2000)]
        [InlineData(5, 5000)]
        [InlineData(5, 10000)]
        [InlineData(10, 1000)]
        [InlineData(10, 10000)]
        [InlineData(50, 500)]
        [InlineData(50, 1000)]
        [InlineData(100, 100)]
        [InlineData(100, 500)]
        public void ShouldPerformAllOperationsConcurrently(int numberOfAccounts, int operations)
        {
            var accounts = new double[numberOfAccounts];
            Array.Fill(accounts, InitialAmount);
            var bankingService = new BankingService(accounts);

            var actions = new List<Action>();
            var ids = Enumerable.Range(0, numberOfAccounts).ToArray();
            foreach (var id in ids)
            {
                for (var i = 0; i < operations; i++)
                {
                    actions.Add(() => { bankingService.Withdraw(id, 5); });
                    actions.Add(() => { bankingService.Deposit(id, 4); });
                }
            }

            var shuffledActions = actions.OrderBy(x => Rnd.Next()).ToList();
            if (!Task.WaitAll(shuffledActions.Select(Task.Run).ToArray(), Timeout))
            {
                throw new TimeoutException();
            }

            foreach (var id in ids)
            {
                Assert.Equal(InitialAmount - operations, bankingService.GetBalance(id));
            }
        }
    }
}
