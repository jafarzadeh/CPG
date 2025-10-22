using Volo.Abp.Data;

namespace Avid.PaymentService.Payments;

public interface IPaymentItem : IHasExtraProperties
{
    string ItemType { get; }

    string ItemKey { get; }

    decimal OriginalPaymentAmount { get; }

    decimal PaymentDiscount { get; }

    decimal ActualPaymentAmount { get; }

    decimal RefundAmount { get; }

    decimal PendingRefundAmount { get; }
}