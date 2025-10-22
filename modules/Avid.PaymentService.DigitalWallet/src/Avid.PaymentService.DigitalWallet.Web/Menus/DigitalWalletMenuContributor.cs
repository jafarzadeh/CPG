using System.Collections.Generic;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Localization;
using Avid.PaymentService.DigitalWallet.Permissions;
using Volo.Abp.UI.Navigation;

namespace Avid.PaymentService.DigitalWallet.Web.Menus;

public class DigitalWalletMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenu(context);
        }
    }

    private async Task ConfigureMainMenu(MenuConfigurationContext context)
    {
        var
            l = context
                .GetLocalizer<
                    DigitalWalletResource>(); //Add main menu items.
        var DigitalWalletManagementMenuItem =
            new ApplicationMenuItem(DigitalWalletMenus.Prefix, l["Menu:DigitalWalletManagement"]);
        if (await context.IsGrantedAsync(DigitalWalletPermissions.Account.Manage.ManageDefault))
        {
            DigitalWalletManagementMenuItem.AddItem(new ApplicationMenuItem(DigitalWalletMenus.Account,
                l["Menu:Account"], "/PaymentService/DigitalWallet/Accounts/Account"));
        }

        if (await context.IsGrantedAsync(DigitalWalletPermissions.WithdrawalRequest.Manage))
        {
            DigitalWalletManagementMenuItem.AddItem(new ApplicationMenuItem(DigitalWalletMenus.WithdrawalRequest,
                l["Menu:WithdrawalRequest"], "/PaymentService/DigitalWallet/WithdrawalRequests/WithdrawalRequest"));
        }

        if (!DigitalWalletManagementMenuItem.Items.IsNullOrEmpty())
        {
            var paymentServiceMenuItem = context.Menu.GetAdministration().Items.GetOrAdd(
                i => i.Name == DigitalWalletMenus.ModuleGroupPrefix,
                () => new ApplicationMenuItem(DigitalWalletMenus.ModuleGroupPrefix, l["Menu:PaymentService"],
                    icon: "fa fa-credit-card"));
            paymentServiceMenuItem.Items.Add(DigitalWalletManagementMenuItem);
        }
    }
}