using System;
using Volo.Abp.MultiTenancy;

namespace Avid.PaymentService.Payments;

[Serializable]
public class CancelPaymentEto : IMultiTenant
{
    public CancelPaymentEto(Guid? tenantId, Guid paymentId)
    {
        TenantId = tenantId;
        PaymentId = paymentId;
    }

    public Guid PaymentId { get; set; }
    public Guid? TenantId { get; set; }
}