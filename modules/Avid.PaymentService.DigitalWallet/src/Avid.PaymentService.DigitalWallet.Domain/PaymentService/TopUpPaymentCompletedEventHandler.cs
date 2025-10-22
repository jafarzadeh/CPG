using System;
using System.Linq;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Accounts;
using Avid.PaymentService.DigitalWallet.Options.AccountGroups;
using Avid.PaymentService.DigitalWallet.Transactions;
using Avid.PaymentService.Payments;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Avid.PaymentService.DigitalWallet.PaymentService;

public class TopUpPaymentCompletedEventHandler : IDistributedEventHandler<PaymentCompletedEto>, ITransientDependency
{
    private readonly IAccountGroupConfigurationProvider _accountGroupConfigurationProvider;
    private readonly IAccountRepository _accountRepository;
    private readonly ICurrentTenant _currentTenant;
    private readonly IGuidGenerator _guidGenerator;
    private readonly ITransactionRepository _transactionRepository;

    public TopUpPaymentCompletedEventHandler(IGuidGenerator guidGenerator, ITransactionRepository transactionRepository,
        IAccountGroupConfigurationProvider accountGroupConfigurationProvider, IAccountRepository accountRepository,
        ICurrentTenant currentTenant)
    {
        _guidGenerator = guidGenerator;
        _transactionRepository = transactionRepository;
        _accountGroupConfigurationProvider = accountGroupConfigurationProvider;
        _accountRepository = accountRepository;
        _currentTenant = currentTenant;
    }

    [UnitOfWork(true)]
    public virtual async Task HandleEventAsync(PaymentCompletedEto eventData)
    {
        var payment = eventData.Payment;
        using var currentTenant = _currentTenant.Change(payment.TenantId);
        foreach (var item in payment.PaymentItems.Where(item =>
                     item.ItemType == DigitalWalletConsts.TopUpPaymentItemType))
        {
            var changedBalance = GetChangedBalance(item);
            var account = await _accountRepository.GetAsync(Guid.Parse(item.ItemKey));
            var configuration = _accountGroupConfigurationProvider.Get(account.AccountGroupName);
            var transaction = new Transaction(_guidGenerator.Create(), _currentTenant.Id, account.Id, account.UserId,
                payment.Id, TransactionType.Debit, DigitalWalletConsts.TopUpActionName, payment.PaymentMethod,
                payment.ExternalTradingCode, configuration.Currency, changedBalance, account.Balance);
            await _transactionRepository.InsertAsync(transaction, true);
            if (payment.Currency != _accountGroupConfigurationProvider.Get(account.AccountGroupName).Currency)
                throw new CurrencyNotSupportedException(payment.Currency);

            account.ChangeBalance(configuration, changedBalance);
            account.SetPendingTopUpPaymentId(null);
            await _accountRepository.UpdateAsync(account, true);
        }
    }

    protected virtual decimal GetChangedBalance(PaymentItemEto paymentItem)
    {
        var changedBalance = paymentItem.OriginalPaymentAmount;
        if (!changedBalance.IsBetween(decimal.Zero, DigitalWalletConsts.AccountMaxBalance))
            throw new AmountOverflowException(decimal.Zero, DigitalWalletConsts.AccountMaxBalance);

        return changedBalance;
    }
}