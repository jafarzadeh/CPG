using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class PayeeAccountNotFoundException : BusinessException
{
    public PayeeAccountNotFoundException(string paymentMethod) : base(PaymentServiceErrorCodes.PayeeAccountNotFound)
    {
        WithData("paymentMethod", paymentMethod);
    }
}