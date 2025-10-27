using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class PayeeConfigurationMissingValueException : BusinessException
{
    public PayeeConfigurationMissingValueException(string paymentMethod, string configurationKey) : 
        base(PaymentServiceErrorCodes.PayeeConfigurationMissingValue)
    {
        WithData("paymentMethod", paymentMethod);
        WithData("configurationKey", configurationKey);
    }
}