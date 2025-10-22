using System.Threading.Tasks;

namespace Avid.PaymentService.Web.Pages.PaymentService.Payments.Payment;

public class IndexModel : PaymentServicePageModel
{
    public async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}