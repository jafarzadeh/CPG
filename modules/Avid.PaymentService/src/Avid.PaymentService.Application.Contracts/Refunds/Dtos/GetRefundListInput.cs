using System;
using Volo.Abp.Application.Dtos;

namespace Avid.PaymentService.Refunds.Dtos;

public class GetRefundListInput : PagedAndSortedResultRequestDto
{
    public Guid? PaymentId { get; set; }
}