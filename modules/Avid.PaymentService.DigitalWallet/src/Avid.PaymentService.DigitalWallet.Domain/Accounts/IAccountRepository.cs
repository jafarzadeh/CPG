using System;
using Volo.Abp.Domain.Repositories;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public interface IAccountRepository : IRepository<Account, Guid>
{
}