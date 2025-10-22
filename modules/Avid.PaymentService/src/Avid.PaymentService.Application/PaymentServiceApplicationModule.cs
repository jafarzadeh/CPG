using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Avid.PaymentService;

[DependsOn(
    typeof(PaymentServiceDomainModule),
    typeof(PaymentServiceApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
)]
public class PaymentServiceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<PaymentServiceApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options
                .AddMaps<PaymentServiceApplicationModule>(); // todo: https://github.com/abpframework/abp/issues/15404
        });
    }
}