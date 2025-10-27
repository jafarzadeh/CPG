using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class DuplicatePaymentItemIdException : BusinessException
{
    public DuplicatePaymentItemIdException() : base(PaymentServiceErrorCodes.DuplicatePaymentItemId)
    {
    }
}