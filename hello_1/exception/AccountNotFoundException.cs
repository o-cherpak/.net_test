namespace hello_1.exception;

public class AccountNotFoundException : Exception
{
    public AccountNotFoundException(string? message) : base(message)
    {
    }
}