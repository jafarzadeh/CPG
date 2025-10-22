using System;
using System.Collections.Generic;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;

namespace Avid.PaymentService.Payments;

public class PaymentEto : ExtensibleObject, IPayment, IMultiTenant
{
    public DateTime CreationTime { get; set; }
    public List<PaymentItemEto> PaymentItems { get; set; }

    public Guid? TenantId { get; set; }
    public Guid UserId { get; set; }

    public Guid Id { get; set; }

    public string PaymentMethod { get; set; }

    public string PayeeAccount { get; set; }

    public string ExternalTradingCode { get; set; }

    public string Currency { get; set; }

    public decimal OriginalPaymentAmount { get; set; }

    public decimal PaymentDiscount { get; set; }

    public decimal ActualPaymentAmount { get; set; }

    public decimal RefundAmount { get; set; }

    public decimal PendingRefundAmount { get; set; }

    public DateTime? CompletionTime { get; set; }

    public DateTime? CanceledTime { get; set; }

    IEnumerable<IPaymentItem> IPayment.PaymentItems => PaymentItems;
}