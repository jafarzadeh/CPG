using System.Threading.Tasks;
using Avid.PaymentService.Refunds;
using Volo.Abp.Data;

namespace Avid.PaymentService.Payments;

public interface IPaymentServiceProvider
{
    Task OnPaymentStartedAsync(Payment payment, ExtraPropertyDictionary configurations);

    Task OnCancelStartedAsync(Payment payment);

    Task OnRefundStartedAsync(Payment payment, Refund refund);
}