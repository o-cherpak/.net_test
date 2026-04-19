namespace hello_1;

public class Transaction
{
    private Guid _id;
    private Guid _accountFromId;
    private Guid _accountToId;
    private decimal _amount;
    private DateTime _sendTime;
    private TransactionType _type;
    

    public Transaction(Guid accountFromId, Guid accountToId, decimal amount, TransactionType type)
    {
        _accountFromId = accountFromId;
        _accountToId = accountToId;
        _amount = amount;
        _id = Guid.NewGuid();
        _sendTime = DateTime.Now;
        _type = type;
    }

    public TransactionType Type => _type;

    public DateTime SendTime => _sendTime;

    public decimal Amount => _amount;

    public Guid AccountToId => _accountToId;

    public Guid AccountFromId => _accountFromId;

    public Guid Id => _id;
}