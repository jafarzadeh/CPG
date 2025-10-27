using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class PaymentAmountInvalidException : BusinessException
{
    public PaymentAmountInvalidException(decimal paymentAmount) : base(
        message: $"Payment amount {paymentAmount} is invalid.")
    {
    }

    public PaymentAmountInvalidException(decimal paymentAmount, string paymentMethod) : 
        base(PaymentServiceErrorCodes.PaymentAmountInvalid)
    {
        WithData("paymentAmount", paymentAmount);
        WithData("paymentMethod", paymentMethod);
    }
}