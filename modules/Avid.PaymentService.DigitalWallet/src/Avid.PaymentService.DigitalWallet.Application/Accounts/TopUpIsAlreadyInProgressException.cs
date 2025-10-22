using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class TopUpIsAlreadyInProgressException : BusinessException
{
    public TopUpIsAlreadyInProgressException() : base("TopUpIsAlreadyInProgress",
        "Another top up for the account is already in progress.")
    {
    }
}