using hello_1.exception;

namespace hello_1;

public class SavingsAccount : AccountBase
{
    public SavingsAccount(decimal balance, Guid ownerId) : base(balance, ownerId)
    {
    }

    private decimal _tax = 0.01m;

    public override void Withdraw(decimal amount)
    {
        decimal totalAmount = amount + (amount * _tax);
        if (Balance < totalAmount)
        {
            throw new InsufficientFundsException("You don't have enough money for this operation.");
        }

        Balance -= totalAmount;
    }

    public override void GetInfo()
    {
        Console.WriteLine($"Saving Account, Balance  {Balance}");
    }
}