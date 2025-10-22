using PaymentServiceSample.Localization;
using Volo.Abp.Application.Services;

namespace PaymentServiceSample;

/* Inherit your application services from this class.     */
public abstract class PaymentServiceSampleAppService : ApplicationService
{
    protected PaymentServiceSampleAppService()
    {
        LocalizationResource = typeof(PaymentServiceSampleResource);
    }
}