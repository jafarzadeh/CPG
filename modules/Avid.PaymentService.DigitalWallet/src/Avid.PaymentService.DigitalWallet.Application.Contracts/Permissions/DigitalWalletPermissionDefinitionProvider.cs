using Avid.PaymentService.DigitalWallet.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Avid.PaymentService.DigitalWallet.Permissions;

public class DigitalWalletPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DigitalWalletPermissions.GroupName, L("Permission:PaymentServiceDigitalWallet"));
        var accountPermission =
            myGroup.AddPermission(DigitalWalletPermissions.Account.Default, L("Permission:Account"));
        accountPermission.AddChild(DigitalWalletPermissions.Account.Manage.ManageDefault, L("Permission:Manage"));
        accountPermission.AddChild(DigitalWalletPermissions.Account.Manage.ChangeBalance,
            L("Permission:ChangeBalance"));
        accountPermission.AddChild(DigitalWalletPermissions.Account.Manage.ChangeLockedBalance,
            L("Permission:ChangeLockedBalance"));
        accountPermission.AddChild(DigitalWalletPermissions.Account.TopUp, L("Permission:TopUp"));
        accountPermission.AddChild(DigitalWalletPermissions.Account.Withdraw, L("Permission:Withdraw"));
        var transactionPermission =
            myGroup.AddPermission(DigitalWalletPermissions.Transaction.Default, L("Permission:Transaction"));
        transactionPermission.AddChild(DigitalWalletPermissions.Transaction.Manage, L("Permission:Manage"));
        var withdrawalRecordPermission = myGroup.AddPermission(DigitalWalletPermissions.WithdrawalRecord.Default,
            L("Permission:WithdrawalRecord"));
        withdrawalRecordPermission.AddChild(DigitalWalletPermissions.WithdrawalRecord.Manage, L("Permission:Manage"));
        var withdrawalRequestPermission = myGroup.AddPermission(DigitalWalletPermissions.WithdrawalRequest.Default,
            L("Permission:WithdrawalRequest"));
        withdrawalRequestPermission.AddChild(DigitalWalletPermissions.WithdrawalRequest.Manage, L("Permission:Manage"));
        withdrawalRequestPermission.AddChild(DigitalWalletPermissions.WithdrawalRequest.Review, L("Permission:Review"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DigitalWalletResource>(name);
    }
}