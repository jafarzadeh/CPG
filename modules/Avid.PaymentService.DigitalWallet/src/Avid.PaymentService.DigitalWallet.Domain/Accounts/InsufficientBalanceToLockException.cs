using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class InsufficientBalanceToLockException : BusinessException
{
    public InsufficientBalanceToLockException(decimal lockedBalance, decimal balance) : base(
        message: $"Failed to lock {lockedBalance} balance. The current balance ({balance}) is insufficient to lock.")
    {
    }
}