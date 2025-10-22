using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Avid.PaymentService.DigitalWallet;

[DependsOn(typeof(PaymentServiceDigitalWalletApplicationContractsModule), typeof(AbpHttpClientModule))]
public class PaymentServiceDigitalWalletHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = PaymentServiceRemoteServiceConsts.RemoteServiceName;

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(typeof(PaymentServiceDigitalWalletApplicationContractsModule).Assembly,
            RemoteServiceName);
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PaymentServiceDigitalWalletHttpApiClientModule>();
        });
    }
}