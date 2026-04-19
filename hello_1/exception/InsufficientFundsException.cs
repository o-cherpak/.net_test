namespace hello_1.exception;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string? message) : base(message)
    {
    }
}