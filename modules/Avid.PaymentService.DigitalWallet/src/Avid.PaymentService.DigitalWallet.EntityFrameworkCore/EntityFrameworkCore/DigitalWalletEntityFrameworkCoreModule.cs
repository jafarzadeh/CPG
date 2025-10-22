using Avid.PaymentService.DigitalWallet.Accounts;
using Avid.PaymentService.DigitalWallet.Transactions;
using Avid.PaymentService.DigitalWallet.WithdrawalRecords;
using Avid.PaymentService.DigitalWallet.WithdrawalRequests;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Volo.Abp.Modularity;

namespace Avid.PaymentService.DigitalWallet.EntityFrameworkCore;

[DependsOn(typeof(PaymentServiceDigitalWalletDomainModule), typeof(AbpEntityFrameworkCoreModule))]
public class PaymentServiceDigitalWalletEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<PaymentServiceDigitalWalletDbContext>(
            delegate(IAbpDbContextRegistrationOptionsBuilder options)
            {
                options.AddRepository<Account, AccountRepository>();
                options.AddRepository<Transaction, TransactionRepository>();
                options.AddRepository<WithdrawalRecord, WithdrawalRecordRepository>();
                options.AddRepository<WithdrawalRequest, WithdrawalRequestRepository>();
            });
    }
}