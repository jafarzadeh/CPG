using System.Threading.Tasks;
using Volo.Abp.Data;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public abstract class AccountWithdrawalProvider : IAccountWithdrawalProvider
{
    public AccountWithdrawalProvider(IAccountWithdrawalManager accountWithdrawalManager)
    {
        AccountWithdrawalManager = accountWithdrawalManager;
    }

    protected IAccountWithdrawalManager AccountWithdrawalManager { get; }

    public abstract Task OnStartWithdrawalAsync(Account account, string withdrawalMethod, decimal amount,
        ExtraPropertyDictionary inputExtraProperties);

    public abstract Task OnCompleteWithdrawalAsync(Account account);
    public abstract Task OnCancelWithdrawalAsync(Account account);
}