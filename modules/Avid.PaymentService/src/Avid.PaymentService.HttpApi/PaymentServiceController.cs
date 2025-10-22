using Avid.PaymentService.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Avid.PaymentService;

[Area(PaymentServiceRemoteServiceConsts.ModuleName)]
[ApiExplorerSettings(GroupName = "AvidPaymentService")]
public abstract class PaymentServiceController : AbpControllerBase
{
    protected PaymentServiceController()
    {
        LocalizationResource = typeof(PaymentServiceResource);
    }
}