using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class UnknownWithdrawalMethodException : BusinessException
{
    public UnknownWithdrawalMethodException(string withdrawalMethod) : base(
        message: $"Withdrawal method {withdrawalMethod} does not exist.")
    {
    }
}