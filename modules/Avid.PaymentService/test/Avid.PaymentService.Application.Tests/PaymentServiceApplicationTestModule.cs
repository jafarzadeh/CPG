using Volo.Abp.Modularity;

namespace Avid.PaymentService;

[DependsOn(
    typeof(PaymentServiceApplicationModule),
    typeof(PaymentServiceDomainTestModule)
)]
public class PaymentServiceApplicationTestModule : AbpModule
{
}