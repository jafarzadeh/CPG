using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Avid.PaymentService.Refunds;

public interface IRefundRepository : IRepository<Refund, Guid>
{
    Task<Refund> FindByPaymentIdAsync(Guid paymentId, CancellationToken cancellationToken = default);
}