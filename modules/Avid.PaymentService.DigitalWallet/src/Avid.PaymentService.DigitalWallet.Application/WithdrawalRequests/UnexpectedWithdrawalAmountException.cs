using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRequests;

public class UnexpectedWithdrawalAmountException : BusinessException
{
    public UnexpectedWithdrawalAmountException() : base("WrongWithdrawalAmount", "The refund amount is unexpected.")
    {
    }
}