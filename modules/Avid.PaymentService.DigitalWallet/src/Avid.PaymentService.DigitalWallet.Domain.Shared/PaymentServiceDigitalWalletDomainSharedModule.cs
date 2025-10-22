using Avid.PaymentService.DigitalWallet.Localization;
using Volo.Abp.Domain;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Avid.PaymentService.DigitalWallet;

[DependsOn(typeof(AbpValidationModule), typeof(AbpDddDomainSharedModule))]
public class PaymentServiceDigitalWalletDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PaymentServiceDigitalWalletDomainSharedModule>();
        });
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources.Add<DigitalWalletResource>("en").AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/DigitalWallet");
        });
        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Avid.PaymentService.DigitalWallet", typeof(DigitalWalletResource));
        });
    }
}