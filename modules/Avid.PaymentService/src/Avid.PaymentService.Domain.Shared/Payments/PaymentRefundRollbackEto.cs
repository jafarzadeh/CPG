using System;
using Avid.PaymentService.Refunds;
using Volo.Abp.MultiTenancy;

namespace Avid.PaymentService.Payments;

[Serializable]
public class PaymentRefundRollbackEto : IMultiTenant
{
    public PaymentRefundRollbackEto(
        PaymentEto payment,
        RefundEto refund)
    {
        TenantId = payment.TenantId;
        Payment = payment;
        Refund = refund;
    }

    public PaymentEto Payment { get; set; }

    public RefundEto Refund { get; set; }
    public Guid? TenantId { get; set; }
}