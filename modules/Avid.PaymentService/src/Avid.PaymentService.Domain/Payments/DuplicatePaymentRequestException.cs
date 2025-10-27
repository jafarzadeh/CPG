using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class DuplicatePaymentRequestException : BusinessException
{
    public DuplicatePaymentRequestException() 
        : base(PaymentServiceErrorCodes.DuplicatePaymentRequest)
    {
    }
}