using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Avid.PaymentService.DigitalWallet;

[DependsOn(typeof(PaymentServiceDigitalWalletDomainSharedModule), typeof(PaymentServiceApplicationContractsModule),
    typeof(AbpDddApplicationContractsModule), typeof(AbpAuthorizationModule))]
public class PaymentServiceDigitalWalletApplicationContractsModule : AbpModule
{
}