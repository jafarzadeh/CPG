using System.Threading.Tasks;
using Volo.Abp.Data;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public interface IAccountWithdrawalProvider
{
    Task OnStartWithdrawalAsync(Account account, string withdrawalMethod, decimal amount,
        ExtraPropertyDictionary inputExtraProperties);

    Task OnCompleteWithdrawalAsync(Account account);
    Task OnCancelWithdrawalAsync(Account account);
}