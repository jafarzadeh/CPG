using System.Net;
using Avid.PaymentService.DigitalWallet.Localization;
using Avid.PaymentService.DigitalWallet.Web.Menus;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;
using Volo.Abp.VirtualFileSystem;

namespace Avid.PaymentService.DigitalWallet.Web;

[DependsOn(typeof(PaymentServiceDigitalWalletApplicationContractsModule), typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAutoMapperModule), typeof(AbpUsersAbstractionModule))]
public class PaymentServiceDigitalWalletWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(DigitalWalletResource),
                typeof(PaymentServiceDigitalWalletWebModule).Assembly);
        });
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(PaymentServiceDigitalWalletWebModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpExceptionHttpStatusCodeOptions>(o =>
        {
            o.Map(DigitalWalletErrorCodes.UnknownWithdrawalMethod, HttpStatusCode.BadRequest);
            o.Map(DigitalWalletErrorCodes.AmountFieldOverflow, HttpStatusCode.BadRequest);
            o.Map(DigitalWalletErrorCodes.AmountOverflow, HttpStatusCode.BadRequest);
            o.Map(DigitalWalletErrorCodes.LockedBalanceIsLessThenPendingWithdrawalAmount, HttpStatusCode.BadRequest);
            o.Map(DigitalWalletErrorCodes.WithdrawalAmountExceedDailyLimit, HttpStatusCode.BadRequest);
            o.Map(DigitalWalletErrorCodes.WithdrawalInProgressNotFound, HttpStatusCode.BadRequest);
            o.Map(DigitalWalletErrorCodes.WithdrawalIsAlreadyInProgress, HttpStatusCode.BadRequest);
            o.Map(DigitalWalletErrorCodes.InsufficientBalanceToLock, HttpStatusCode.BadRequest);
        });


        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new DigitalWalletMenuContributor());
        });
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PaymentServiceDigitalWalletWebModule>();
        });
        context.Services.AddAutoMapperObjectMapper<PaymentServiceDigitalWalletWebModule>();
        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<PaymentServiceDigitalWalletWebModule>(true); });
        Configure<RazorPagesOptions>(options =>
        {
            //Configure authorization.
        });
    }
}