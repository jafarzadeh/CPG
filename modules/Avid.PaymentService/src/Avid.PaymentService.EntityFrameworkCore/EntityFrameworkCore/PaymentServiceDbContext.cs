using Avid.PaymentService.Payments;
using Avid.PaymentService.Refunds;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Avid.PaymentService.EntityFrameworkCore;

[ConnectionStringName(PaymentServiceDbProperties.ConnectionStringName)]
public class PaymentServiceDbContext : AbpDbContext<PaymentServiceDbContext>, IPaymentServiceDbContext
{
    public PaymentServiceDbContext(DbContextOptions<PaymentServiceDbContext> options)
        : base(options)
    {
    }

    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentItem> PaymentItems { get; set; }
    public DbSet<Refund> Refunds { get; set; }
    public DbSet<RefundItem> RefundItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePaymentService();
    }
}