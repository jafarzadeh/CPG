using Avid.PaymentService.Localization;
using Volo.Abp.Application.Services;

namespace Avid.PaymentService;

public abstract class PaymentServiceAppService : ApplicationService
{
    protected PaymentServiceAppService()
    {
        LocalizationResource = typeof(PaymentServiceResource);
        ObjectMapperContext = typeof(PaymentServiceApplicationModule);
    }
}