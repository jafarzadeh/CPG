using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Avid.PaymentService;

[DependsOn(
    typeof(PaymentServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
)]
public class PaymentServiceApplicationContractsModule : AbpModule
{
}