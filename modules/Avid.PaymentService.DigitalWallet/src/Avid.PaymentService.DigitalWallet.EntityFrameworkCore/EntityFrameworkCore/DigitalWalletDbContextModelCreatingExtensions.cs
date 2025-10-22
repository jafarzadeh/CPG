using System;
using Avid.PaymentService.DigitalWallet.Accounts;
using Avid.PaymentService.DigitalWallet.Transactions;
using Avid.PaymentService.DigitalWallet.WithdrawalRecords;
using Avid.PaymentService.DigitalWallet.WithdrawalRequests;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Avid.PaymentService.DigitalWallet.EntityFrameworkCore;

public static class DigitalWalletDbContextModelCreatingExtensions
{
    public static void ConfigurePaymentServiceDigitalWallet(this ModelBuilder builder,
        Action<DigitalWalletModelBuilderConfigurationOptions> optionsAction = null)
    {
        Check.NotNull(builder, nameof(builder));
        var options = new DigitalWalletModelBuilderConfigurationOptions(DigitalWalletDbProperties.DbTablePrefix,
            DigitalWalletDbProperties.DbSchema);
        optionsAction
            ?.Invoke(options);
        builder.Entity<Account>(b =>
        {
            b.ToTable(options.TablePrefix + "Accounts", options.Schema);
            b.ConfigureByConvention(); /* Configure more properties here */
            b.Property(x => x.Balance).HasColumnType("decimal(20,8)");
            b.Property(x => x.LockedBalance).HasColumnType("decimal(20,8)");
            b.Property(x => x.PendingWithdrawalAmount).HasColumnType("decimal(20,8)");
            b.HasIndex(x => x.UserId);
        });
        builder.Entity<Transaction>(b =>
        {
            b.ToTable(options.TablePrefix + "Transactions", options.Schema);
            b.ConfigureByConvention(); /* Configure more properties here */
            b.Property(x => x.ChangedBalance).HasColumnType("decimal(20,8)");
            b.Property(x => x.OriginalBalance).HasColumnType("decimal(20,8)");
            b.HasIndex(x => x.AccountId);
            b.HasIndex(x => x.AccountUserId);
        });
        builder.Entity<WithdrawalRecord>(b =>
        {
            b.ToTable(options.TablePrefix + "WithdrawalRecords", options.Schema);
            b.ConfigureByConvention(); /* Configure more properties here */
            b.Property(x => x.Amount).HasColumnType("decimal(20,8)");
        });
        builder.Entity<WithdrawalRequest>(b =>
        {
            b.ToTable(options.TablePrefix + "WithdrawalRequests", options.Schema);
            b.ConfigureByConvention(); /* Configure more properties here */
            b.Property(x => x.Amount).HasColumnType("decimal(20,8)");
        });
    }
}