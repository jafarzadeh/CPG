using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avid.PaymentService.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Avid.PaymentService.Refunds;

public class RefundRepository : EfCoreRepository<IPaymentServiceDbContext, Refund, Guid>, IRefundRepository
{
    public RefundRepository(IDbContextProvider<IPaymentServiceDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Refund>> WithDetailsAsync()
    {
        return (await base.WithDetailsAsync()).Include(x => x.RefundItems);
    }

    public virtual async Task<Refund> FindByPaymentIdAsync(Guid paymentId,
        CancellationToken cancellationToken = default)
    {
        return await (await WithDetailsAsync())
            .Where(x => x.PaymentId == paymentId && !x.CanceledTime.HasValue && !x.CompletedTime.HasValue)
            .SingleOrDefaultAsync(cancellationToken);
    }
}