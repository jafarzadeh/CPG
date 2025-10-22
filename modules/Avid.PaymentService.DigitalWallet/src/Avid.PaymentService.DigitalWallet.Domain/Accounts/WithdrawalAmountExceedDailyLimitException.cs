using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class WithdrawalAmountExceedDailyLimitException : BusinessException
{
    public WithdrawalAmountExceedDailyLimitException() : base("WithdrawalAmountExceedDailyLimit",
        "The maximum daily withdrawal limit has been exceeded.")
    {
    }
}