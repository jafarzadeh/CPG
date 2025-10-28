using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class UnknownWithdrawalMethodException : BusinessException
{
    public UnknownWithdrawalMethodException(string withdrawalMethod) :
        base(DigitalWalletErrorCodes.UnknownWithdrawalMethod)
    {
        WithData("withdrawalMethod", withdrawalMethod);
    }
}