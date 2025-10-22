using Avid.PaymentService.DigitalWallet.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Avid.PaymentService.DigitalWallet;

[Area(PaymentServiceRemoteServiceConsts.ModuleName)]
[ApiExplorerSettings(GroupName = "AvidPaymentServiceDigitalWallet")]
public abstract class DigitalWalletController : AbpControllerBase
{
    protected DigitalWalletController()
    {
        LocalizationResource = typeof(DigitalWalletResource);
    }
}