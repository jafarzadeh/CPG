using Avid.PaymentService.DigitalWallet.Accounts;
using Avid.PaymentService.DigitalWallet.Transactions;
using Avid.PaymentService.DigitalWallet.WithdrawalRecords;
using Avid.PaymentService.DigitalWallet.WithdrawalRequests;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Avid.PaymentService.DigitalWallet.EntityFrameworkCore;

[ConnectionStringName(DigitalWalletDbProperties.ConnectionStringName)]
public class PaymentServiceDigitalWalletDbContext : AbpDbContext<PaymentServiceDigitalWalletDbContext>,
    IPaymentServiceDigitalWalletDbContext
{
    public PaymentServiceDigitalWalletDbContext(DbContextOptions<PaymentServiceDigitalWalletDbContext> options) :
        base(options)
    {
    } /* Add DbSet for each Aggregate Root here. Example:         * public DbSet<Question> Questions { get; set; }         */

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<WithdrawalRecord> WithdrawalRecords { get; set; }
    public DbSet<WithdrawalRequest> WithdrawalRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigurePaymentServiceDigitalWallet();
    }
}