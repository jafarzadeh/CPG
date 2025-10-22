using System;
using Avid.PaymentService.DigitalWallet.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRequests;

public class WithdrawalRequestRepository :
    EfCoreRepository<IPaymentServiceDigitalWalletDbContext, WithdrawalRequest, Guid>, IWithdrawalRequestRepository
{
    public WithdrawalRequestRepository(IDbContextProvider<IPaymentServiceDigitalWalletDbContext> dbContextProvider) :
        base(dbContextProvider)
    {
    }
}