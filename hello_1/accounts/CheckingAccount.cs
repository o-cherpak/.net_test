using hello_1.exception;

namespace hello_1;

public class CheckingAccount : AccountBase
{
    public CheckingAccount(decimal balance, Guid ownerId) : base(balance, ownerId)
    {
    }

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount < -500)
        {
            throw new InsufficientFundsException("You got limit of this operation (< -500$)");
        }

        Balance -= amount;
    }

    public override void GetInfo()
    {
        Console.WriteLine($"Cheсking Account, Balance  {Balance}");
    }
}