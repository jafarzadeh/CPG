using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.PaymentService;

public class AccountTopingUpOtherAccountsIsNotAllowedException : BusinessException
{
    public AccountTopingUpOtherAccountsIsNotAllowedException(string accountGroupName) : base(
        message: $"The account ({accountGroupName}) is not allowed to top up other accounts.")
    {
    }
}