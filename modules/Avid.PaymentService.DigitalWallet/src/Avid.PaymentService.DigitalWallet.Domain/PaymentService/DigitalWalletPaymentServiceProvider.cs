using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Accounts;
using Avid.PaymentService.DigitalWallet.Options.AccountGroups;
using Avid.PaymentService.DigitalWallet.Transactions;
using Avid.PaymentService.Payments;
using Avid.PaymentService.Refunds;
using Volo.Abp.Data;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace Avid.PaymentService.DigitalWallet.PaymentService;

public class DigitalWalletPaymentServiceProvider : PaymentServiceProvider
{
    private readonly IAccountGroupConfigurationProvider _accountGroupConfigurationProvider;
    private readonly IAccountRepository _accountRepository;
    private readonly ICurrentTenant _currentTenant;
    private readonly ICurrentUser _currentUser;
    private readonly IGuidGenerator _guidGenerator;
    private readonly IPaymentManager _paymentManager;
    private readonly IPaymentRepository _paymentRepository;
    private readonly ITransactionRepository _transactionRepository;

    public DigitalWalletPaymentServiceProvider(IGuidGenerator guidGenerator, ICurrentUser currentUser,
        ICurrentTenant currentTenant, IPaymentManager paymentManager, IPaymentRepository paymentRepository,
        IAccountRepository accountRepository, ITransactionRepository transactionRepository,
        IAccountGroupConfigurationProvider accountGroupConfigurationProvider)
    {
        _guidGenerator = guidGenerator;
        _currentUser = currentUser;
        _currentTenant = currentTenant;
        _paymentManager = paymentManager;
        _paymentRepository = paymentRepository;
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
        _accountGroupConfigurationProvider = accountGroupConfigurationProvider;
    }

    public static string PaymentMethod { get; } = "DigitalWallet";

    [UnitOfWork(true)]
    public override async Task OnPaymentStartedAsync(Payment payment, ExtraPropertyDictionary configurations)
    {
        if (payment.ActualPaymentAmount <= decimal.Zero)
        {
            throw new PaymentAmountInvalidException(payment.ActualPaymentAmount, payment.PaymentMethod);
        }

        if (!Guid.TryParse(configurations.GetOrDefault(DigitalWalletConsts.PaymentAccountIdPropertyName).ToString(),
                out var accountId))
        {
            throw new ArgumentNullException(DigitalWalletConsts.PaymentAccountIdPropertyName);
        }

        var account = await _accountRepository.GetAsync(accountId);
        if (account.UserId != _currentUser.GetId())
        {
            throw new UserIsNotAccountOwnerException(_currentUser.GetId(), accountId);
        }

        payment.SetProperty(DigitalWalletConsts.PaymentAccountIdPropertyName, accountId);
        var accountGroupConfiguration = _accountGroupConfigurationProvider.Get(account.AccountGroupName);
        if (!accountGroupConfiguration.AllowedUsingToTopUpOtherAccounts &&
            payment.PaymentItems.Any(x => x.ItemType == DigitalWalletConsts.TopUpPaymentItemType))
        {
            throw new AccountTopingUpOtherAccountsIsNotAllowedException(account.AccountGroupName);
        }

        if (payment.PaymentItems.Any(x =>
                x.ItemType == DigitalWalletConsts.TopUpPaymentItemType && x.ItemKey == accountId.ToString()))
        {
            throw new SelfTopUpException();
        }

        if (payment.Currency != accountGroupConfiguration.Currency)
        {
            throw new CurrencyNotSupportedException(payment.Currency);
        }

        var accountChangedBalance = -1 * payment.ActualPaymentAmount;
        var transaction = new Transaction(_guidGenerator.Create(), _currentTenant.Id, account.Id, account.UserId,
            payment.Id, TransactionType.Credit, DigitalWalletConsts.PaymentActionName, payment.PaymentMethod,
            payment.ExternalTradingCode, accountGroupConfiguration.Currency, accountChangedBalance, account.Balance);
        await _transactionRepository.InsertAsync(transaction, true);
        account.ChangeBalance(accountGroupConfiguration, accountChangedBalance);
        await _accountRepository.UpdateAsync(account, true);
        await _paymentManager.CompletePaymentAsync(payment);
        await _paymentRepository.UpdateAsync(payment, true);
    }

    public override async Task OnCancelStartedAsync(Payment payment)
    {
        await _paymentManager.CompleteCancelAsync(payment);
    }

    [UnitOfWork(true)]
    public override async Task OnRefundStartedAsync(Payment payment, Refund refund)
    {
        var accountId = payment.GetProperty<Guid?>(DigitalWalletConsts.PaymentAccountIdPropertyName);
        if (accountId is null)
        {
            throw new ArgumentNullException(DigitalWalletConsts.PaymentAccountIdPropertyName);
        }

        var account = await _accountRepository.GetAsync(accountId.Value);
        var configuration = _accountGroupConfigurationProvider.Get(account.AccountGroupName);
        var accountChangedBalance = refund.RefundAmount;
        var transaction = new Transaction(_guidGenerator.Create(), _currentTenant.Id, account.Id, account.UserId,
            payment.Id, TransactionType.Debit, DigitalWalletConsts.RefundActionName, payment.PaymentMethod,
            payment.ExternalTradingCode, configuration.Currency, accountChangedBalance, account.Balance);
        await _transactionRepository.InsertAsync(transaction, true);
        account.ChangeBalance(configuration, accountChangedBalance);
        await _accountRepository.UpdateAsync(account, true);
        await _paymentManager.CompleteRefundAsync(payment, refund);
    }
}