using Avid.PaymentService.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Avid.PaymentService.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class PaymentServicePageModel : AbpPageModel
{
    protected PaymentServicePageModel()
    {
        LocalizationResourceType = typeof(PaymentServiceResource);
        ObjectMapperContext = typeof(PaymentServiceWebModule);
    }
}