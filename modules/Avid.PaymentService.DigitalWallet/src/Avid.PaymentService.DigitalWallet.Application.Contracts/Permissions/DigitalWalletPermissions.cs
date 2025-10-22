using Volo.Abp.Reflection;

namespace Avid.PaymentService.DigitalWallet.Permissions;

public class DigitalWalletPermissions
{
    public const string GroupName = "Avid.PaymentService.DigitalWallet";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(DigitalWalletPermissions));
    }

    public class Account
    {
        public const string Default = GroupName + ".Account";
        public const string TopUp = Default + ".TopUp";
        public const string Withdraw = Default + ".Withdraw";

        public class Manage
        {
            public const string ManageDefault = Default + ".Manage";
            public const string ChangeBalance = ManageDefault + ".ChangeBalance";
            public const string ChangeLockedBalance = ManageDefault + ".ChangeLockedBalance";
        }
    }

    public class Transaction
    {
        public const string Default = GroupName + ".Transaction";
        public const string Manage = Default + ".Manage";
    }

    public class WithdrawalRecord
    {
        public const string Default = GroupName + ".WithdrawalRecord";
        public const string Manage = Default + ".Manage";
    }

    public class WithdrawalRequest
    {
        public const string Default = GroupName + ".WithdrawalRequest";
        public const string Manage = Default + ".Manage";
        public const string Review = Default + ".Review";
    }
}