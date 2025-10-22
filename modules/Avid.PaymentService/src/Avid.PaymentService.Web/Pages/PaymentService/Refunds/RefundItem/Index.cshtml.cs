using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Avid.PaymentService.Web.Pages.PaymentService.Refunds.RefundItem;

public class IndexModel : PaymentServicePageModel
{
    [BindProperty(SupportsGet = true)] public Guid RefundId { get; set; }

    public async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}