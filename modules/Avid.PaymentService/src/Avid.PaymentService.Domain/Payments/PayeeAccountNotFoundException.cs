using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class PayeeAccountNotFoundException : BusinessException
{
    public PayeeAccountNotFoundException(string paymentMethod) : base(
        message: $"Cannot find the payee account of payment method {paymentMethod}.")
    {
    }
}