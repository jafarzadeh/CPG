using System;
using Volo.Abp.Domain.Repositories;

namespace Avid.PaymentService.DigitalWallet.Transactions;

public interface ITransactionRepository : IRepository<Transaction, Guid>
{
}