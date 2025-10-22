using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Options.AccountGroups;
using Avid.PaymentService.DigitalWallet.Transactions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Uow;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class ChangeAccountBalanceEventHandler : IDistributedEventHandler<ChangeAccountBalanceEto>, ITransientDependency
{
    private readonly IAccountGroupConfigurationProvider _accountGroupConfigurationProvider;
    private readonly IAccountRepository _accountRepository;
    private readonly ICurrentTenant _currentTenant;
    private readonly IGuidGenerator _guidGenerator;
    private readonly ITransactionRepository _transactionRepository;

    public ChangeAccountBalanceEventHandler(ICurrentTenant currentTenant, IGuidGenerator guidGenerator,
        IAccountRepository accountRepository, ITransactionRepository transactionRepository,
        IAccountGroupConfigurationProvider accountGroupConfigurationProvider)
    {
        _currentTenant = currentTenant;
        _guidGenerator = guidGenerator;
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
        _accountGroupConfigurationProvider = accountGroupConfigurationProvider;
    }

    [UnitOfWork(true)]
    public async Task HandleEventAsync(ChangeAccountBalanceEto eventData)
    {
        using var changeTenant = _currentTenant.Change(eventData.TenantId);
        var changedBalance = eventData.ChangedBalance;
        var account = await _accountRepository.GetAsync(eventData.AccountId);
        var configuration = _accountGroupConfigurationProvider.Get(account.AccountGroupName);
        var transactionType = changedBalance > decimal.Zero ? TransactionType.Debit : TransactionType.Credit;
        var transaction = new Transaction(_guidGenerator.Create(), eventData.TenantId, account.Id, account.UserId, null,
            transactionType, eventData.ActionName, DigitalWalletConsts.ChangeBalancePaymentMethod, null,
            configuration.Currency, changedBalance, account.Balance);
        eventData.MapExtraPropertiesTo(transaction, MappingPropertyDefinitionChecks.None);
        await _transactionRepository.InsertAsync(transaction, true);
        account.ChangeBalance(configuration, changedBalance);
        await _accountRepository.UpdateAsync(account, true);
    }
}