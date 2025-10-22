using System;
using System.Linq;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRecords;

public class WithdrawalRecordRepository :
    EfCoreRepository<IPaymentServiceDigitalWalletDbContext, WithdrawalRecord, Guid>, IWithdrawalRecordRepository
{
    public WithdrawalRecordRepository(IDbContextProvider<IPaymentServiceDigitalWalletDbContext> dbContextProvider) :
        base(dbContextProvider)
    {
    }

    public async Task<decimal> GetCompletedTotalAmountAsync(Guid accountId, DateTime beginTime, DateTime endTime)
    {
        return await (await GetDbSetAsync())
            .Where(x => x.AccountId == accountId && x.CompletionTime >= beginTime && x.CompletionTime <= endTime)
            .SumAsync(x => x.Amount);
    }
}