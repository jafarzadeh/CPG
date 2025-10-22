using System;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Accounts;
using Avid.PaymentService.DigitalWallet.Accounts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Avid.PaymentService.DigitalWallet.Web.Pages.PaymentService.DigitalWallet.Accounts.Account;

public class ChangeBalanceModalModel : DigitalWalletPageModel
{
    private readonly IAccountAppService _service;

    public ChangeBalanceModalModel(IAccountAppService service)
    {
        _service = service;
    }

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty] public ChangeBalanceInput ChangeBalanceInput { get; set; }
    public AccountDto Account { get; set; }

    public async Task OnGetAsync()
    {
        Account = await _service.GetAsync(Id);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _service.ChangeBalanceAsync(Id, ChangeBalanceInput);
        return NoContent();
    }
}