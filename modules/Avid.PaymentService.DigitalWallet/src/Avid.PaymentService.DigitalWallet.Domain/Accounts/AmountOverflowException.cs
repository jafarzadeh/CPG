using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class AmountOverflowException : BusinessException
{
    public AmountOverflowException(decimal min, decimal max) 
        : base(DigitalWalletErrorCodes.AmountOverflow)
    {
        WithData("max", max);
        WithData("min", min);
    }

    public AmountOverflowException(string field, decimal min, decimal max) 
        : base(DigitalWalletErrorCodes.AmountFieldOverflow)
    {
        WithData("field", field);
        WithData("max", max);
        WithData("min", min);
    }
}