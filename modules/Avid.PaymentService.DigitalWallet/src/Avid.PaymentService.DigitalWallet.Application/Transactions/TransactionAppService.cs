using System;
using System.Linq;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Accounts;
using Avid.PaymentService.DigitalWallet.Permissions;
using Avid.PaymentService.DigitalWallet.Transactions.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace Avid.PaymentService.DigitalWallet.Transactions;

public class TransactionAppService : ReadOnlyAppService<Transaction, TransactionDto, Guid, GetTransactionListInput>,
    ITransactionAppService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _repository;

    public TransactionAppService(IAccountRepository accountRepository, ITransactionRepository repository) :
        base(repository)
    {
        _accountRepository = accountRepository;
        _repository = repository;
    }

    protected override string GetPolicyName { get; set; } = DigitalWalletPermissions.Transaction.Default;
    protected override string GetListPolicyName { get; set; } = DigitalWalletPermissions.Transaction.Default;

    public override async Task<TransactionDto> GetAsync(Guid id)
    {
        var dto = await base.GetAsync(id);
        var account = await _accountRepository.GetAsync(dto.AccountId);
        if (account.UserId != CurrentUser.GetId())
        {
            await AuthorizationService.CheckAsync(DigitalWalletPermissions.Transaction.Manage);
        }

        return dto;
    }

    [Authorize]
    public override async Task<PagedResultDto<TransactionDto>> GetListAsync(GetTransactionListInput input)
    {
        var account = await _accountRepository.GetAsync(input.AccountId);
        if (account.UserId != CurrentUser.GetId())
        {
            await AuthorizationService.CheckAsync(DigitalWalletPermissions.Transaction.Manage);
        }

        return await base.GetListAsync(input);
    }

    protected override async Task<IQueryable<Transaction>> CreateFilteredQueryAsync(GetTransactionListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input)).Where(x => x.AccountId == input.AccountId);
    }
}