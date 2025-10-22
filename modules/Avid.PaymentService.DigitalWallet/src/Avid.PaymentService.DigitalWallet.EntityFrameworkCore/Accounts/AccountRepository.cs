using System;
using Avid.PaymentService.DigitalWallet.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class AccountRepository : EfCoreRepository<IPaymentServiceDigitalWalletDbContext, Account, Guid>,
    IAccountRepository
{
    public AccountRepository(IDbContextProvider<IPaymentServiceDigitalWalletDbContext> dbContextProvider) : base(
        dbContextProvider)
    {
    }
}