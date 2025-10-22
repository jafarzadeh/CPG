using Avid.PaymentService.DigitalWallet.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Avid.PaymentService.DigitalWallet.Web.Pages;

/* Inherit your PageModel classes from this class.     */
public abstract class DigitalWalletPageModel : AbpPageModel
{
    protected DigitalWalletPageModel()
    {
        LocalizationResourceType = typeof(DigitalWalletResource);
        ObjectMapperContext = typeof(PaymentServiceDigitalWalletWebModule);
    }
}