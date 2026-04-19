using hello_1.exception;

namespace hello_1;

public class Bank
{
    private List<Customer> Customers = new List<Customer>();

    public IReadOnlyList<Customer> GetCustomers()
    {
        return Customers.AsReadOnly();
    }

    public void AddCustomer(string name)
    {
        Customer newCustomer = new Customer(name);

        Customers.Add(newCustomer);
    }

    public void Transfer(AccountBase accountFrom, AccountBase accountTo, decimal amount)
    {
        try
        {
            accountFrom.Withdraw(amount);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"You don't have enough money for this operation. {ex.Message}");
            return;
        }
        catch (WithdrawalNotAllowedException ex)
        {
            Console.WriteLine($"Withdrawal Not Allowed Here {ex.Message}");
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unknown error: {ex.Message}");
            return;
        }

        try
        {
            accountTo.Deposit(amount);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            accountFrom.Deposit(amount);
            throw;
        }
    }
}