using System;
using Volo.Abp.Application.Dtos;

namespace Avid.PaymentService.Refunds.Dtos;

[Serializable]
public class RefundItemDto : ExtensibleFullAuditedEntityDto<Guid>, IRefundItem
{
    public Guid PaymentItemId { get; set; }

    public decimal RefundAmount { get; set; }

    public string CustomerRemark { get; set; }

    public string StaffRemark { get; set; }
}