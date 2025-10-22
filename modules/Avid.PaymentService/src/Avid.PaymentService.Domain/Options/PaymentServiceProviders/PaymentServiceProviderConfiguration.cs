using System;

namespace Avid.PaymentService.Options.PaymentServiceProviders;

public class PaymentServiceProviderConfiguration
{
    public PaymentServiceProviderConfiguration()
    {
    }

    public PaymentServiceProviderConfiguration(Type providerType, string providerName)
    {
        ProviderType = providerType;
        ProviderName = providerName;
    }

    public Type ProviderType { get; set; }

    public string ProviderName { get; set; }
}