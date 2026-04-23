using System.Text.Json;
using hello_1.exception;
using hello_1.services;

namespace hello_1;

public class Bank
{
    private List<Customer> _customers { get; set; } = new List<Customer>();
    private List<Transaction> _transactionsHistory { get; set; } = new List<Transaction>();

    public IReadOnlyList<Customer> GetCustomers()
    {
        return _customers.AsReadOnly();
    }

    public void AddCustomer(string name)
    {
        Customer newCustomer = new Customer(name);

        _customers.Add(newCustomer);
    }

    public void Transfer(AccountBase accountFrom, AccountBase accountTo, decimal amount)
    {
        String errorMessenge = null;

        try
        {
            accountFrom.Withdraw(amount);
        }
        catch (InsufficientFundsException ex)
        {
            errorMessenge = $"You don't have enough money for this operation. {ex.Message}";
        }
        catch (WithdrawalNotAllowedException ex)
        {
            errorMessenge = $"Withdrawal Not Allowed Here {ex.Message}";
        }
        catch (Exception ex)
        {
            errorMessenge = $"Unknown error: {ex.Message}";
        }

        if (errorMessenge is not null)
        {
            Transaction transaction =
                new Transaction(accountFrom.GetId(), accountTo.GetId(), amount, TransactionType.Failed);
            _transactionsHistory.Add(transaction);
            Console.WriteLine(errorMessenge);

            return;
        }

        try
        {
            accountTo.Deposit(amount);
        }
        catch (Exception e)
        {
            accountFrom.Deposit(amount);
            errorMessenge = e.Message;
        }

        if (errorMessenge is null)
        {
            Transaction transaction =
                new Transaction(accountFrom.GetId()
                    , accountTo.GetId(), amount, TransactionType.Success);
            _transactionsHistory.Add(transaction);
            Console.WriteLine("Transaction Success");
        }
        else
        {
            Transaction transaction =
                new Transaction(accountFrom.GetId()
                    , accountTo.GetId(), amount, TransactionType.Failed);
            _transactionsHistory.Add(transaction);
            Console.WriteLine(errorMessenge);
        }
    }

    public List<Transaction> GetLastTransactions(int count = 1, TransactionType? type = null)
    {
        var query = _transactionsHistory;

        if (type.HasValue)
        {
            query = _transactionsHistory
                .Where(tran => tran.Type == type)
                .TakeLast(count).ToList();

            return query;
        }

        query = _transactionsHistory.TakeLast(count).ToList();

        return query;
    }

    public async Task SaveTransactions()
    {
        BankSerializer bs = new BankSerializer();

        var json = JsonSerializer.Serialize(_transactionsHistory, bs.option);

        await File.WriteAllTextAsync(bs.pathToSaveTransactions, json);
    }

    public async Task LoadTransactions()
    {
        BankSerializer bs = new BankSerializer();

        if (!File.Exists(bs.pathToSaveTransactions)) return;

        var json = await File.ReadAllTextAsync(bs.pathToSaveTransactions);
        _transactionsHistory = JsonSerializer.Deserialize<List<Transaction>>(json, bs.option);
    }
}