using Avid.PaymentService.DigitalWallet.ObjectExtending;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Avid.PaymentService.DigitalWallet;

[DependsOn(typeof(PaymentServiceDigitalWalletDomainModule),
    typeof(PaymentServiceDigitalWalletApplicationContractsModule), typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule))]
public class PaymentServiceDigitalWalletApplicationModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PaymentServiceDigitalWalletApplicationObjectExtensions.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<PaymentServiceDigitalWalletApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options
                .AddMaps<
                    PaymentServiceDigitalWalletApplicationModule>(); // todo: https://github.com/abpframework/abp/issues/15404
        });
    }
}