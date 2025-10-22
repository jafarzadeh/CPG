using System;
using Volo.Abp.Application.Dtos;

namespace Avid.PaymentService.DigitalWallet.Accounts.Dtos;

[Serializable]
public class GetAccountListInput : PagedAndSortedResultRequestDto
{
    public Guid? UserId { get; set; }
}