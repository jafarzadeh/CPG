using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class InsufficientBalanceToLockException : BusinessException
{
    public InsufficientBalanceToLockException(decimal lockedBalance, decimal balance) : 
        base(DigitalWalletErrorCodes.InsufficientBalanceToLock)
    {
        WithData("lockedBalance", lockedBalance);
        WithData("balance", balance);
    }
}