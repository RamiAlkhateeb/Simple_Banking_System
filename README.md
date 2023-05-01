# Simple_Banking_System

implemention of a simple banking system that only supports the deposit and withdrawal of money. Initially, there are n bank accounts, the ith of which has money[i] money on the balance, and there is a service IBankService supporting three operations:

``` C#
public interface IBankingService
{
    double GetBalance(int accountId);
    void Withdraw(int accountId, double amount);
    void Deposit(int accountId, double amount);
}
```

* The method GetBalance returns the amount of money in the account accountId.

* The method Withdraw either withdraws amount money from the account accountId or throws an exception if there is not enough money available in the account.

* The method Deposit deposits amount money to the account accountId.


The methods should also throw an exception if either there is no account with accountId or amount is not positive. 

This is a TDD task — with unit tests which fail at the beginning, the  task is to implement a solution which makes them pass.

[execution time limit] 20 seconds
