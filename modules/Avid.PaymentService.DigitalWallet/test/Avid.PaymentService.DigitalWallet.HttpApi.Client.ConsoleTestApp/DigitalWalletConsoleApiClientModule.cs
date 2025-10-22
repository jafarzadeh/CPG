using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Avid.PaymentService.DigitalWallet;

[DependsOn(typeof(PaymentServiceDigitalWalletHttpApiClientModule), typeof(AbpHttpClientIdentityModelModule))]
public class DigitalWalletConsoleApiClientModule : AbpModule
{
}