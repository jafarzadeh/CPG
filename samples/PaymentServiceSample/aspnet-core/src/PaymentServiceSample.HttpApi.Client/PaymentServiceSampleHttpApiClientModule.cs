using Avid.PaymentService;
using Avid.PaymentService.DigitalWallet;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;

namespace PaymentServiceSample;

[DependsOn(typeof(PaymentServiceSampleApplicationContractsModule), typeof(AbpAccountHttpApiClientModule),
    typeof(AbpIdentityHttpApiClientModule), typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpTenantManagementHttpApiClientModule), typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(PaymentServiceHttpApiClientModule), typeof(PaymentServiceDigitalWalletHttpApiClientModule))]
public class PaymentServiceSampleHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(typeof(PaymentServiceSampleApplicationContractsModule).Assembly);
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PaymentServiceSampleHttpApiClientModule>();
        });
    }
}