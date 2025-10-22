using System.Threading.Tasks;

namespace Avid.PaymentService.DigitalWallet.Web.Pages.PaymentService.DigitalWallet.WithdrawalRequests.WithdrawalRequest;

public class IndexModel : DigitalWalletPageModel
{
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}