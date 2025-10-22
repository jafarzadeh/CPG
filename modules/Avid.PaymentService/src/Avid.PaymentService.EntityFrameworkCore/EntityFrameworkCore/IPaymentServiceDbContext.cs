using Avid.PaymentService.Payments;
using Avid.PaymentService.Refunds;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Avid.PaymentService.EntityFrameworkCore;

[ConnectionStringName(PaymentServiceDbProperties.ConnectionStringName)]
public interface IPaymentServiceDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    DbSet<Payment> Payments { get; set; }
    DbSet<PaymentItem> PaymentItems { get; set; }
    DbSet<Refund> Refunds { get; set; }
    DbSet<RefundItem> RefundItems { get; set; }
}