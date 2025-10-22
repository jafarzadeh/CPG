using System;
using Volo.Abp.Application.Dtos;

namespace Avid.PaymentService.DigitalWallet.Transactions.Dtos;

[Serializable]
public class GetTransactionListInput : PagedAndSortedResultRequestDto
{
    public Guid AccountId { get; set; }
}