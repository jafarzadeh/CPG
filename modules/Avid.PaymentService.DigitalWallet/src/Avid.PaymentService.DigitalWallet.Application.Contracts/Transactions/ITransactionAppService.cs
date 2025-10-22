using System;
using Avid.PaymentService.DigitalWallet.Transactions.Dtos;
using Volo.Abp.Application.Services;

namespace Avid.PaymentService.DigitalWallet.Transactions;

public interface ITransactionAppService : IReadOnlyAppService<TransactionDto, Guid, GetTransactionListInput>
{
}