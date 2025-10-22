using System;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.WithdrawalRequests.Dtos;
using Volo.Abp.Application.Services;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRequests;

public interface
    IWithdrawalRequestAppService : IReadOnlyAppService<WithdrawalRequestDto, Guid, GetWithdrawalRequestListInput>
{
    Task<WithdrawalRequestDto> ReviewAsync(Guid id, ReviewWithdrawalRequestInput input);
}