using Avid.PaymentService;
using Avid.PaymentService.DigitalWallet;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.TenantManagement;

namespace PaymentServiceSample;

[DependsOn(typeof(PaymentServiceSampleApplicationContractsModule), typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule), typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule), typeof(AbpFeatureManagementHttpApiModule),
    typeof(PaymentServiceHttpApiModule), typeof(PaymentServiceDigitalWalletHttpApiModule))]
public class PaymentServiceSampleHttpApiModule : AbpModule
{
}