namespace hello_1;

public abstract class AccountBase
{
    protected AccountBase(decimal balance, Guid ownerId)
    {
        Balance = balance;
        OwnerId = ownerId;
        Id = Guid.NewGuid();
    }

    protected Guid Id { get; set; }
    protected decimal Balance { get; set; }
    protected Guid OwnerId { get; set; }

    public virtual void Deposit(decimal amount)
    {
        Balance += amount;
    }
    public abstract void Withdraw(decimal amount);
    public abstract void GetInfo();
}