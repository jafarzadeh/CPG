using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Users;

namespace Avid.PaymentService.DigitalWallet.Web.Pages.PaymentService.DigitalWallet.Accounts.Account;

public class IndexModel : DigitalWalletPageModel
{
    [BindProperty(SupportsGet = true)] public Guid? UserId { get; set; }
    public string UserName { get; set; }

    public virtual async Task OnGetAsync()
    {
        if (!UserId.HasValue)
        {
            return;
        }

        var userLookupServiceProvider =
            LazyServiceProvider.LazyGetRequiredService<IExternalUserLookupServiceProvider>();
        var userData = await userLookupServiceProvider.FindByIdAsync(UserId.Value);
        UserName = userData.UserName;
    }
}