using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.PaymentService;

public class SelfTopUpException : BusinessException
{
    public SelfTopUpException() : base(message: "An account cannot top up itself.")
    {
    }
}