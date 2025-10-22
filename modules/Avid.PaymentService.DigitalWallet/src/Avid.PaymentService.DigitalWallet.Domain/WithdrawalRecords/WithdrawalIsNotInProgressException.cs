using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRecords;

public class WithdrawalIsNotInProgressException : BusinessException
{
    public WithdrawalIsNotInProgressException() : base("WithdrawalIsNotInProgress",
        "The withdrawal is not in progress.")
    {
    }
}