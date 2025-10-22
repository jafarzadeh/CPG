using System;
using Avid.PaymentService.Refunds;
using Volo.Abp.MultiTenancy;

namespace Avid.PaymentService.Payments;

[Serializable]
public class RefundPaymentEto : IMultiTenant
{
    public RefundPaymentEto(
        Guid? tenantId,
        CreateRefundInput createRefundInput)
    {
        TenantId = tenantId;
        CreateRefundInput = createRefundInput;
    }

    public CreateRefundInput CreateRefundInput { get; set; }
    public Guid? TenantId { get; set; }
}