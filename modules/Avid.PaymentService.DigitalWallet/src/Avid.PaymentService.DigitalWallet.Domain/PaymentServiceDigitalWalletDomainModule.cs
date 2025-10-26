using Avid.PaymentService.DigitalWallet.ObjectExtending;
using Volo.Abp.Modularity;
using Volo.Abp.Users;

namespace Avid.PaymentService.DigitalWallet;

[DependsOn(typeof(PaymentServiceDigitalWalletDomainSharedModule),
    typeof(PaymentServiceDomainModule),
    typeof(AbpUsersDomainModule))]
public class PaymentServiceDigitalWalletDomainModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PaymentServiceDigitalWalletDomainObjectExtensions.Configure();
    }
}