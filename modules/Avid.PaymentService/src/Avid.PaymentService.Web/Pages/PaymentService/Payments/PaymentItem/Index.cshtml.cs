using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Avid.PaymentService.Web.Pages.PaymentService.Payments.PaymentItem;

public class IndexModel : PaymentServicePageModel
{
    [BindProperty(SupportsGet = true)] public Guid PaymentId { get; set; }

    public async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}