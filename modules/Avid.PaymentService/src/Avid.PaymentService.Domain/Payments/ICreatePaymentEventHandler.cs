using Volo.Abp.EventBus.Distributed;

namespace Avid.PaymentService.Payments;

public interface ICreatePaymentEventHandler : IDistributedEventHandler<CreatePaymentEto>
{
}