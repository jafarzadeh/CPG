namespace Avid.PaymentService.Options.PaymentServiceProviders;

public interface IPaymentServiceProviderConfigurationProvider
{
    PaymentServiceProviderConfiguration Get(string providerName);
}