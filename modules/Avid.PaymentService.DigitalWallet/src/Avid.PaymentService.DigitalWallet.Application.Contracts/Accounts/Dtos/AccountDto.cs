using System;
using Volo.Abp.Application.Dtos;

namespace Avid.PaymentService.DigitalWallet.Accounts.Dtos;

[Serializable]
public class AccountDto : ExtensibleAuditedEntityDto<Guid>
{
    public string AccountGroupName { get; set; }
    public Guid UserId { get; set; }
    public decimal Balance { get; set; }
    public decimal LockedBalance { get; set; }
    public Guid? PendingTopUpPaymentId { get; set; }
    public Guid? PendingWithdrawalRecordId { get; set; }
    public decimal PendingWithdrawalAmount { get; set; }
}