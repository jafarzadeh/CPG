using Avid.PaymentService.Options.PaymentServiceProviders;

namespace Avid.PaymentService.Options;

public class PaymentServiceOptions
{
    public PaymentServiceOptions()
    {
        Providers = new PaymentServiceProviderConfigurations();
    }

    public PaymentServiceProviderConfigurations Providers { get; }
}