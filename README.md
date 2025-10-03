# Test Driven Development

TDD is important to make, Test are crucial to avoid design s,smells, what is design smells?
- Rigidity: The cost of making a single change is very high
- Fragility: Small changes in one module cause bugs appearance in other
- Immobility: Components can't be reused in other systems

![tdd](https://miro.medium.com/v2/resize:fit:1100/format:webp/1*0hLR8MddRc5O0gqaIVJLjQ.png)

## TDD 3 Laws
First, when talking about TDD, we need to mention the three laws of TDD:
1- You must write a failing test before you write any production code.
2- You must not write more of a test than is sufficient to fail, or fail to compile.
3- You must not write more production code than is sufficient to make the currently failing test pass.

## TDD Techniques
- Faking
- Traingulation
- Implementation

Also, we need to write test in this order: 
Exceptional - Degenerate - Ancillary

Degenerative cases cause core funtionality to do nothing
Ancillary: for example -> get size of a stack
=> Ancillary behavior support core function


# TDD Banking System

Implementation of a simple banking system that only supports the deposit and withdrawal of money. Initially, there are n bank accounts, the ith of which has money[i] money on the balance, and there is a service IBankService supporting three operations:

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

This is a TDD task — with the following unit tests:
* Functional Tests
    * Should withdraw when amount is valid and account exists
    * Should throw ArgumentException when withdraw from non-existing account
    * Should throw ArgumentException when withdraw wrong amount of money
    * Should throw ArgumentException when withdraw too much money
    * Should throw ArgumentException when deposit to non-existing account
    * Should throw ArgumentException when deposit wrong amount of money
    * Should deposit when amount is valid and account exists

* Stress Tests
    * Should perform all operations concurrently




[execution time limit] 20 seconds
