using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRequests;

public class WithdrawalRequestHasBeenReviewedException : BusinessException
{
    public WithdrawalRequestHasBeenReviewedException() : base("WithdrawalRequestHasBeenReviewed",
        "The review has been reviewed.")
    {
    }
}