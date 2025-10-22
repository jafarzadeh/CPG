using Volo.Abp.EventBus.Distributed;

namespace Avid.PaymentService.Payments;

public interface IRefundPaymentEventHandler : IDistributedEventHandler<RefundPaymentEto>
{
}