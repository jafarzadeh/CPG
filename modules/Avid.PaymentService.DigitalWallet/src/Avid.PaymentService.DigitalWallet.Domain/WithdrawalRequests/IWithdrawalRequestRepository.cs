using System;
using Volo.Abp.Domain.Repositories;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRequests;

public interface IWithdrawalRequestRepository : IRepository<WithdrawalRequest, Guid>
{
}