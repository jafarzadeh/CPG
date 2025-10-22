using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Avid.PaymentService;

[DependsOn(
    typeof(PaymentServiceHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
)]
public class PaymentServiceConsoleApiClientModule : AbpModule
{
}