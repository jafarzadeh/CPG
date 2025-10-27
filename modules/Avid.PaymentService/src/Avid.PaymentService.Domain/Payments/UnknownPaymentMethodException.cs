using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class UnknownPaymentMethodException : BusinessException
{
    public UnknownPaymentMethodException(string paymentMethod) 
        : base(PaymentServiceErrorCodes.UnknownPaymentMethod)
    {
        WithData("paymentMethod", paymentMethod);
    }
}