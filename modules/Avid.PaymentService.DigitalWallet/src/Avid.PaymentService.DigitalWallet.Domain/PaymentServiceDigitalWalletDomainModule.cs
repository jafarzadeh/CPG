using Avid.PaymentService.DigitalWallet.ObjectExtending;
using Volo.Abp.Modularity;

namespace Avid.PaymentService.DigitalWallet;

[DependsOn(typeof(PaymentServiceDigitalWalletDomainSharedModule), typeof(PaymentServiceDomainModule))]
public class PaymentServiceDigitalWalletDomainModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PaymentServiceDigitalWalletDomainObjectExtensions.Configure();
    }
}