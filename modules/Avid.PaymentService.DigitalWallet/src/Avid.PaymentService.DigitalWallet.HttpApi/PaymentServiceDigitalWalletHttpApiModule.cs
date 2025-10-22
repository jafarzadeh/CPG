using Avid.PaymentService.DigitalWallet.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Avid.PaymentService.DigitalWallet;

[DependsOn(typeof(PaymentServiceDigitalWalletApplicationContractsModule), typeof(AbpAspNetCoreMvcModule))]
public class PaymentServiceDigitalWalletHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(PaymentServiceDigitalWalletHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources.Get<DigitalWalletResource>().AddBaseTypes(typeof(AbpUiResource));
        });
    }
}