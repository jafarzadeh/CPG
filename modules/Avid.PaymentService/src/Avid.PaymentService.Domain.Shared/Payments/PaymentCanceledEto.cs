using System;
using Volo.Abp.MultiTenancy;

namespace Avid.PaymentService.Payments;

[Serializable]
public class PaymentCanceledEto : IMultiTenant
{
    public PaymentCanceledEto(PaymentEto payment)
    {
        TenantId = payment.TenantId;
        Payment = payment;
    }

    public PaymentEto Payment { get; set; }
    public Guid? TenantId { get; set; }
}