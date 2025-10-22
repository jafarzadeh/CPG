using Avid.PaymentService.DigitalWallet.Accounts;
using Avid.PaymentService.DigitalWallet.Transactions;
using Avid.PaymentService.DigitalWallet.WithdrawalRecords;
using Avid.PaymentService.DigitalWallet.WithdrawalRequests;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Avid.PaymentService.DigitalWallet.EntityFrameworkCore;

[ConnectionStringName(DigitalWalletDbProperties.ConnectionStringName)]
public interface IPaymentServiceDigitalWalletDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:         * DbSet<Question> Questions { get; }         */
    DbSet<Account> Accounts { get; set; }
    DbSet<Transaction> Transactions { get; set; }
    DbSet<WithdrawalRecord> WithdrawalRecords { get; set; }
    DbSet<WithdrawalRequest> WithdrawalRequests { get; set; }
}