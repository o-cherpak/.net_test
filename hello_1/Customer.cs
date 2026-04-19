namespace hello_1;

public class Customer
{
    public Customer(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public enum Account
    {
        Checking,
        Deposit,
        Saving
    }

    public List<AccountBase> Accounts => _accounts;

    public Guid Id { get; init; }
    public string Name { get; set; }
    private List<AccountBase> _accounts = new List<AccountBase>();

    public void CreateAccount(Account type, decimal balance)
    {
        switch (type)
        {
            case Account.Checking:
                CheckingAccount newCheckingAccount = new CheckingAccount(balance, Id);

                _accounts.Add(newCheckingAccount);
                break;

            case Account.Deposit:
                DepositAccount newDepositAccount = new DepositAccount(balance, Id);

                _accounts.Add(newDepositAccount);
                break;

            case Account.Saving:
                SavingsAccount savingsAccount = new SavingsAccount(balance, Id);

                _accounts.Add(savingsAccount);
                break;

            default:
                Console.WriteLine("Type does not exist");
                break;
        }
    }

    public void GetAccountsInfo()
    {
        foreach (var account in Accounts)
        {
            account.GetInfo();
        }
    }
}