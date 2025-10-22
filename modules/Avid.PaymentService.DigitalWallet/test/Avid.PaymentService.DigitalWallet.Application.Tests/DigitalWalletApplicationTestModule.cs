using Volo.Abp.Modularity;

namespace Avid.PaymentService.DigitalWallet;

[DependsOn(typeof(PaymentServiceApplicationModule), typeof(PaymentServiceDigitalWalletApplicationModule),
    typeof(DigitalWalletDomainTestModule))]
public class DigitalWalletApplicationTestModule : AbpModule
{
}