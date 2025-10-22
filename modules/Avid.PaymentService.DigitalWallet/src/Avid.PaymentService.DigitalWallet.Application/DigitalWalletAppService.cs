using Avid.PaymentService.DigitalWallet.Localization;
using Volo.Abp.Application.Services;

namespace Avid.PaymentService.DigitalWallet;

public abstract class DigitalWalletAppService : ApplicationService
{
    protected DigitalWalletAppService()
    {
        LocalizationResource = typeof(DigitalWalletResource);
        ObjectMapperContext = typeof(PaymentServiceDigitalWalletApplicationModule);
    }
}