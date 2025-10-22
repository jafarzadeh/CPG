using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class WithdrawalInProgressNotFoundException : BusinessException
{
    public WithdrawalInProgressNotFoundException() : base("WithdrawalInProgressNotFound",
        "The withdrawal in progress not found.")
    {
    }
}