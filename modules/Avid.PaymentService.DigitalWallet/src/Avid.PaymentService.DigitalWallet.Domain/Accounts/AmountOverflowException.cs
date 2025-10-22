using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class AmountOverflowException : BusinessException
{
    public AmountOverflowException(decimal min, decimal max) : base(
        message: $"The amount should be greater than {min} and less then {max}")
    {
    }

    public AmountOverflowException(string field, decimal min, decimal max) : base(
        message: $"The {field} should be greater than {min} and less then {max}")
    {
    }
}