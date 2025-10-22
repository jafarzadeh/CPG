using System;
using Volo.Abp.Application.Dtos;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRequests.Dtos;

[Serializable]
public class WithdrawalRequestDto : ExtensibleFullAuditedEntityDto<Guid>
{
    public Guid AccountId { get; set; }
    public Guid AccountUserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime? ReviewTime { get; set; }
    public Guid? ReviewerUserId { get; set; }
    public bool? IsApproved { get; set; }
}