using Volo.Abp.EventBus.Distributed;

namespace Avid.PaymentService.Payments;

public interface ICancelPaymentEventHandler : IDistributedEventHandler<CancelPaymentEto>
{
}