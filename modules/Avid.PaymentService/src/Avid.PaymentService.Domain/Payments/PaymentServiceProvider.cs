using System.Threading.Tasks;
using Avid.PaymentService.Refunds;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Avid.PaymentService.Payments;

public abstract class PaymentServiceProvider : IPaymentServiceProvider, ITransientDependency
{
    public virtual Task OnPaymentStartedAsync(Payment payment, ExtraPropertyDictionary configurations)
    {
        return Task.CompletedTask;
    }

    public virtual Task OnCancelStartedAsync(Payment payment)
    {
        return Task.CompletedTask;
    }

    public virtual Task OnRefundStartedAsync(Payment payment, Refund refund)
    {
        return Task.CompletedTask;
    }
}