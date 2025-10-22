using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Accounts.Dtos;
using Avid.PaymentService.DigitalWallet.Options;
using Avid.PaymentService.DigitalWallet.Options.AccountGroups;
using Avid.PaymentService.DigitalWallet.Permissions;
using Avid.PaymentService.DigitalWallet.Transactions;
using Avid.PaymentService.Payments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Users;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class AccountAppService : ReadOnlyAppService<Account, AccountDto, Guid, GetAccountListInput>,
    IAccountAppService
{
    private readonly IAccountGroupConfigurationProvider _accountGroupConfigurationProvider;
    private readonly IDistributedEventBus _distributedEventBus;
    private readonly PaymentServiceDigitalWalletOptions _options;
    private readonly IAccountRepository _repository;
    private readonly ITransactionRepository _transactionRepository;

    public AccountAppService(IAccountGroupConfigurationProvider accountGroupConfigurationProvider,
        IOptions<PaymentServiceDigitalWalletOptions> options, IDistributedEventBus distributedEventBus,
        ITransactionRepository transactionRepository, IAccountRepository repository) : base(repository)
    {
        _options = options.Value;
        _accountGroupConfigurationProvider = accountGroupConfigurationProvider;
        _distributedEventBus = distributedEventBus;
        _transactionRepository = transactionRepository;
        _repository = repository;
    }

    protected override string GetPolicyName { get; set; } = DigitalWalletPermissions.Account.Default;
    protected override string GetListPolicyName { get; set; } = DigitalWalletPermissions.Account.Default;

    public override async Task<AccountDto> GetAsync(Guid id)
    {
        var dto = await base.GetAsync(id);
        if (dto.UserId != CurrentUser.GetId())
            await AuthorizationService.CheckAsync(DigitalWalletPermissions.Account.Manage.ManageDefault);

        return dto;
    }

    [Authorize]
    public override async Task<PagedResultDto<AccountDto>> GetListAsync(GetAccountListInput input)
    {
        if (input.UserId != CurrentUser.GetId())
            await AuthorizationService.CheckAsync(DigitalWalletPermissions.Account.Manage.ManageDefault);

        var result = await base.GetListAsync(input);
        if (!input.UserId.HasValue) return result;

        var allAccountGroupNames = _options.AccountGroups.GetAutoCreationAccountGroupNames();
        var missingAccountGroupNames =
            allAccountGroupNames.Except(result.Items.Select(x => x.AccountGroupName)).ToArray();
        foreach (var accountGroupName in missingAccountGroupNames)
            await _repository.InsertAsync(
                new Account(GuidGenerator.Create(), CurrentTenant.Id, accountGroupName, input.UserId.Value, 0, 0),
                true);

        if (!missingAccountGroupNames.IsNullOrEmpty()) result = await base.GetListAsync(input);

        return result;
    }

    [Authorize(DigitalWalletPermissions.Account.Manage.ChangeBalance)]
    public virtual async Task<AccountDto> ChangeBalanceAsync(Guid id, ChangeBalanceInput input)
    {
        var account = await _repository.GetAsync(id);
        var configuration = _accountGroupConfigurationProvider.Get(account.AccountGroupName);
        var transactionType = input.ChangedBalance > decimal.Zero ? TransactionType.Debit : TransactionType.Credit;
        var transaction = new Transaction(GuidGenerator.Create(), CurrentTenant.Id, account.Id, account.UserId,
            null, transactionType, DigitalWalletConsts.ChangeBalanceActionName,
            DigitalWalletConsts.ChangeBalancePaymentMethod, null, configuration.Currency, input.ChangedBalance,
            account.Balance);
        await _transactionRepository.InsertAsync(transaction, true);
        account.ChangeBalance(configuration, input.ChangedBalance);
        await _repository.UpdateAsync(account, true);
        return await MapToGetOutputDtoAsync(account);
    }

    [Authorize(DigitalWalletPermissions.Account.Manage.ChangeLockedBalance)]
    public virtual async Task<AccountDto> ChangeLockedBalanceAsync(Guid id, ChangeLockedBalanceInput input)
    {
        var account = await _repository.GetAsync(id);
        var configuration = _accountGroupConfigurationProvider.Get(account.AccountGroupName);
        account.ChangeLockedBalance(configuration, input.ChangedLockedBalance);
        await _repository.UpdateAsync(account, true);
        return await MapToGetOutputDtoAsync(account);
    }

    [Authorize(DigitalWalletPermissions.Account.TopUp)]
    public virtual async Task TopUpAsync(Guid id, TopUpInput input)
    {
        var account = await _repository.GetAsync(id);
        if (account.UserId != CurrentUser.GetId()) throw new UnauthorizedTopUpException(account.Id);

        if (account.PendingTopUpPaymentId.HasValue) throw new TopUpIsAlreadyInProgressException();

        var configuration = _accountGroupConfigurationProvider.Get(account.AccountGroupName);
        await _distributedEventBus.PublishAsync(new CreatePaymentEto(CurrentTenant.Id, CurrentUser.GetId(),
            input.PaymentMethod, configuration.Currency,
            new List<CreatePaymentItemEto>(new[]
            {
                new CreatePaymentItemEto
                {
                    ItemType = DigitalWalletConsts.TopUpPaymentItemType, ItemKey = account.Id.ToString(),
                    OriginalPaymentAmount = input.Amount
                }
            })));
    }

    [Authorize(DigitalWalletPermissions.Account.Withdraw)]
    public virtual async Task WithdrawAsync(Guid id, WithdrawInput input)
    {
        var account = await _repository.GetAsync(id);
        if (account.UserId != CurrentUser.GetId()) throw new AbpAuthorizationException();

        var accountWithdrawalManager = ServiceProvider.GetRequiredService<IAccountWithdrawalManager>();
        await accountWithdrawalManager.StartWithdrawalAsync(account, input.WithdrawalMethod, input.Amount,
            input.ExtraProperties);
    }

    protected override async Task<IQueryable<Account>> CreateFilteredQueryAsync(GetAccountListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input)).WhereIf(input.UserId.HasValue,
            x => x.UserId == input.UserId.Value);
    }
}