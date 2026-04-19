using hello_1.exception;

namespace hello_1;

public class DepositAccount : AccountBase
{
    public DepositAccount(decimal balance, Guid ownerId) : base(balance, ownerId)
    {
    }

    public override void Withdraw(decimal amount)
    {
        throw new WithdrawalNotAllowedException("Withdrawal Not Allowed Here");
    }

    public override void GetInfo()
    {
        Console.WriteLine($"Deposit Account, Balance  {Balance}");
    }
}