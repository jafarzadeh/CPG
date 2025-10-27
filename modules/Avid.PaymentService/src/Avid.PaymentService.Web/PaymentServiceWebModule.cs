using Avid.PaymentService.Localization;
using Avid.PaymentService.Web.Menus;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Avid.PaymentService.Web;

[DependsOn(
    typeof(PaymentServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAutoMapperModule)
)]
public class PaymentServiceWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(PaymentServiceResource), typeof(PaymentServiceWebModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(PaymentServiceWebModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpExceptionHttpStatusCodeOptions>(o =>
        {
            o.Map(PaymentServiceErrorCodes.AnotherRefundIsInProgress, HttpStatusCode.BadRequest);
            o.Map(PaymentServiceErrorCodes.AnotherRefundTaskIsOnGoing, HttpStatusCode.BadRequest);
            o.Map(PaymentServiceErrorCodes.CurrencyNotSupported, HttpStatusCode.BadRequest);
            o.Map(PaymentServiceErrorCodes.DuplicatePaymentItemId, HttpStatusCode.Conflict);
            o.Map(PaymentServiceErrorCodes.DuplicatePaymentRequest, HttpStatusCode.Conflict);
            o.Map(PaymentServiceErrorCodes.InvalidRefundAmount, HttpStatusCode.BadRequest);
            o.Map(PaymentServiceErrorCodes.PayeeAccountNotFound, HttpStatusCode.NotFound);
            o.Map(PaymentServiceErrorCodes.PayeeConfigurationMissingValue, HttpStatusCode.BadRequest);
            o.Map(PaymentServiceErrorCodes.PaymentAmountInvalid, HttpStatusCode.BadRequest);
            o.Map(PaymentServiceErrorCodes.PaymentIsInUnexpectedStage, HttpStatusCode.BadRequest);
            o.Map(PaymentServiceErrorCodes.UsingUnauthorizedPayment, HttpStatusCode.Unauthorized);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new PaymentServiceMenuContributor());
        });

        Configure<AbpVirtualFileSystemOptions>(options => { options.FileSets.AddEmbedded<PaymentServiceWebModule>(); });

        context.Services.AddAutoMapperObjectMapper<PaymentServiceWebModule>();
        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<PaymentServiceWebModule>(true); });

        Configure<RazorPagesOptions>(options =>
        {
            //Configure authorization.
        });
    }
}