using System;
using System.Linq;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Accounts;
using Avid.PaymentService.DigitalWallet.Permissions;
using Avid.PaymentService.DigitalWallet.WithdrawalRequests.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRequests;

public class WithdrawalRequestAppService :
    ReadOnlyAppService<WithdrawalRequest, WithdrawalRequestDto, Guid, GetWithdrawalRequestListInput>,
    IWithdrawalRequestAppService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IAccountWithdrawalManager _accountWithdrawalManager;
    private readonly IWithdrawalRequestRepository _repository;

    public WithdrawalRequestAppService(IAccountRepository accountRepository,
        IAccountWithdrawalManager accountWithdrawalManager, IWithdrawalRequestRepository repository) : base(repository)
    {
        _accountRepository = accountRepository;
        _accountWithdrawalManager = accountWithdrawalManager;
        _repository = repository;
    }

    protected override string GetPolicyName { get; set; } = DigitalWalletPermissions.WithdrawalRequest.Default;
    protected override string GetListPolicyName { get; set; } = DigitalWalletPermissions.WithdrawalRequest.Default;

    public override async Task<WithdrawalRequestDto> GetAsync(Guid id)
    {
        var dto = await base.GetAsync(id);
        if (dto.AccountUserId != CurrentUser.GetId())
            await AuthorizationService.CheckAsync(DigitalWalletPermissions.WithdrawalRequest.Manage);

        return dto;
    }

    [Authorize]
    public override async Task<PagedResultDto<WithdrawalRequestDto>> GetListAsync(GetWithdrawalRequestListInput input)
    {
        var currentUserId = CurrentUser.GetId();
        if ((input.AccountUserId.HasValue && input.AccountUserId.Value != currentUserId) || (input.AccountId.HasValue &&
                (await _accountRepository.GetAsync(input.AccountId.Value)).UserId != currentUserId))
            await AuthorizationService.CheckAsync(DigitalWalletPermissions.WithdrawalRequest.Manage);

        return await base.GetListAsync(input);
    }

    [Authorize(DigitalWalletPermissions.WithdrawalRequest.Review)]
    public virtual async Task<WithdrawalRequestDto> ReviewAsync(Guid id, ReviewWithdrawalRequestInput input)
    {
        var request = await _repository.GetAsync(id);
        var account = await _accountRepository.GetAsync(request.AccountId);
        request.CheckReviewable();
        if (account.PendingWithdrawalAmount != request.Amount) throw new UnexpectedWithdrawalAmountException();

        request.Review(Clock.Now, CurrentUser.GetId(), input.IsApproved);
        await _repository.UpdateAsync(request, true);
        if (input.IsApproved)
            await _accountWithdrawalManager.CompleteWithdrawalAsync(account);
        else
            await _accountWithdrawalManager.CancelWithdrawalAsync(account);

        return await MapToGetOutputDtoAsync(request);
    }

    protected override async Task<IQueryable<WithdrawalRequest>> CreateFilteredQueryAsync(
        GetWithdrawalRequestListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input)).WhereIf(input.PendingOnly, x => !x.ReviewTime.HasValue)
            .WhereIf(input.AccountId.HasValue, x => x.AccountId == input.AccountId.Value)
            .WhereIf(input.AccountUserId.HasValue, x => x.AccountUserId == input.AccountUserId.Value);
    }
}