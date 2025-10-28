using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class LockedBalanceIsLessThenPendingWithdrawalAmountException : BusinessException
{
    public LockedBalanceIsLessThenPendingWithdrawalAmountException(decimal lockedBalance, decimal withdrawalAmount) :
        base(DigitalWalletErrorCodes.LockedBalanceIsLessThenPendingWithdrawalAmount)
    {
    }
}