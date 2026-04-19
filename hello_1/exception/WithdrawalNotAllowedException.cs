namespace hello_1.exception;

public class WithdrawalNotAllowedException : Exception
{
    public WithdrawalNotAllowedException(string? message) : base(message)
    {
    }
}