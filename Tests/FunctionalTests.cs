using SimpleBankingSystem;

namespace Tests
{
    public class FunctionalTests
    {
        public class WithdrawTests
        {
            private readonly IBankingService _bankingService;

            public WithdrawTests()
            {
                double[] accounts = { 1000.0, 1000.0, 1000.0 };
                _bankingService = new BankingService(accounts);
            }


            [Fact(DisplayName = "Should withdraw when amount is valid and account exists")]
            public void ShouldWithdrawSuccessfullyWhenAmountIsValidAndAccountExists()
            {
                // when
                _bankingService.Withdraw(0, 100);
                _bankingService.Withdraw(1, 200);
                _bankingService.Withdraw(2, 300);

                // then
                Assert.Equal(900, _bankingService.GetBalance(0));
                Assert.Equal(800, _bankingService.GetBalance(1));
                Assert.Equal(700, _bankingService.GetBalance(2));
            }

            [Theory(DisplayName = "Should throw ArgumentException when withdraw from non-existing account")]
            [InlineData(-1)]
            [InlineData(3)]
            public void ShouldThrowArgumentExceptionOnWithdrawalWhenAccountDoesNotExist(int outOfBoundId)
            {
                Assert.Throws<ArgumentException>(() => _bankingService.Withdraw(outOfBoundId, 100));
            }

            [Theory(DisplayName = "Should throw ArgumentException when withdraw wrong amount of money")]
            [InlineData(0.0)]
            [InlineData(-100.0)]
            public void ShouldThrowArgumentExceptionOnWithdrawalWhenAmountIsInvalid(double invalidAmount)
            {
                Assert.Throws<ArgumentException>(() => _bankingService.Withdraw(1, invalidAmount));
            }

            [Fact(DisplayName = "Should throw ArgumentException when withdraw too much money")]
            public void ShouldThrowArgumentExceptionOnWithdrawalWhenInsufficientMoney()
            {
                const double tooMuchMoney = 1500.0;
                Assert.Throws<ArgumentException>(() => _bankingService.Withdraw(1, tooMuchMoney));
            }
        }

        public class DepositTests
        {
            private readonly IBankingService _bankingService;

            public DepositTests()
            {
                double[] accounts = { 1000, 1000, 1000 };
                _bankingService = new BankingService(accounts);
            }


            [Fact(DisplayName = "Should deposit when amount is valid and account exists")]
            public void ShouldDepositSuccessfullyWhenAmountIsValidAndAccountExists()
            {
                // when
                _bankingService.Deposit(0, 100);
                _bankingService.Deposit(1, 200);
                _bankingService.Deposit(2, 300);

                // then
                Assert.Equal(1100, _bankingService.GetBalance(0));
                Assert.Equal(1200, _bankingService.GetBalance(1));
                Assert.Equal(1300, _bankingService.GetBalance(2));
            }

            [Theory(DisplayName = "Should throw ArgumentException when deposit to non-existing account")]
            [InlineData(-1)]
            [InlineData(3)]
            public void ShouldThrowArgumentExceptionOnDepositWhenAccountDoesNotExist(int outOfBoundId)
            {
                Assert.Throws<ArgumentException>(() => _bankingService.Deposit(outOfBoundId, 100));
            }

            [Theory(DisplayName = "Should throw ArgumentException when deposit wrong amount of money")]
            [InlineData(0.0)]
            [InlineData(-100.0)]
            public void ShouldThrowArgumentExceptionOnDepositWhenAmountIsInvalid(double invalidAmount)
            {
                Assert.Throws<ArgumentException>(() => _bankingService.Deposit(1, invalidAmount));
            }
        }
    }
}
