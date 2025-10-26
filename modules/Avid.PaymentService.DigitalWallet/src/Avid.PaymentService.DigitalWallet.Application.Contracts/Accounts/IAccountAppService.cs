using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Accounts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public interface IAccountAppService : IReadOnlyAppService<AccountDto, Guid, GetAccountListInput>
{
    Task<PagedResultDto<AccountDto>> CreateAsync(Guid userId);
    Task<AccountDto> ChangeBalanceAsync(Guid id, ChangeBalanceInput input);
    Task<AccountDto> ChangeLockedBalanceAsync(Guid id, ChangeLockedBalanceInput input);
    Task TopUpAsync(Guid id, TopUpInput input);
    Task WithdrawAsync(Guid id, WithdrawInput input);
}