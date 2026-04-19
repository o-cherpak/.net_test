namespace hello_1;

public class Transaction
{
    private Guid _id;
    private AccountBase _accountFrom;
    private AccountBase _accountTo;
    private decimal _amount;
    private DateTime _sendTime;
    private TransactionType _type;
    

    public Transaction(AccountBase accountFrom, AccountBase accountTo, decimal amount, TransactionType type)
    {
        _accountFrom = accountFrom;
        _accountTo = accountTo;
        _amount = amount;
        _id = Guid.NewGuid();
        _sendTime = DateTime.Now;
        _type = type;
    }

    public TransactionType Type => _type;

    public DateTime SendTime => _sendTime;

    public decimal Amount => _amount;

    public AccountBase AccountTo => _accountTo;

    public AccountBase AccountFrom => _accountFrom;

    public Guid Id => _id;
}