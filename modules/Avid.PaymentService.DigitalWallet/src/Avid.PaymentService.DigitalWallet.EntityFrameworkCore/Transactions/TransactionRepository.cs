using System;
using Avid.PaymentService.DigitalWallet.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Avid.PaymentService.DigitalWallet.Transactions;

public class TransactionRepository : EfCoreRepository<IPaymentServiceDigitalWalletDbContext, Transaction, Guid>,
    ITransactionRepository
{
    public TransactionRepository(IDbContextProvider<IPaymentServiceDigitalWalletDbContext> dbContextProvider) : base(
        dbContextProvider)
    {
    }
}