using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class WithdrawalIsAlreadyInProgressException : BusinessException
{
    public WithdrawalIsAlreadyInProgressException() : base("WithdrawalIsAlreadyInProgress",
        "Another withdrawal for the account is already in progress.")
    {
    }
}