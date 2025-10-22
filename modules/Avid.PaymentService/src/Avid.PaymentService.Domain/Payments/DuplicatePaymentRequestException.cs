using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class DuplicatePaymentRequestException : BusinessException
{
    public DuplicatePaymentRequestException() : base(
        message: "An payment item in the payment request is already in progress.")
    {
    }
}