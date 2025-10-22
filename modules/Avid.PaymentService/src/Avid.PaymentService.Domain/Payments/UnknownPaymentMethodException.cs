using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class UnknownPaymentMethodException : BusinessException
{
    public UnknownPaymentMethodException(string paymentMethod) : base(
        message: $"Payment method {paymentMethod} does not exist.")
    {
    }
}