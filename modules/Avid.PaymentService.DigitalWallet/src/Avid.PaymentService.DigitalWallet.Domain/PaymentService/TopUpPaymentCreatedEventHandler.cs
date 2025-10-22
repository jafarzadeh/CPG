using System;
using System.Linq;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Accounts;
using Avid.PaymentService.Payments;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Avid.PaymentService.DigitalWallet.PaymentService;

public class TopUpPaymentCreatedEventHandler : IDistributedEventHandler<EntityCreatedEto<PaymentEto>>,
    ITransientDependency
{
    private readonly IAccountRepository _accountRepository;
    private readonly ICurrentTenant _currentTenant;

    public TopUpPaymentCreatedEventHandler(ICurrentTenant currentTenant, IAccountRepository accountRepository)
    {
        _currentTenant = currentTenant;
        _accountRepository = accountRepository;
    }

    [UnitOfWork(true)]
    public virtual async Task HandleEventAsync(EntityCreatedEto<PaymentEto> eventData)
    {
        var payment = eventData.Entity;
        var items = payment.PaymentItems.Where(item => item.ItemType == DigitalWalletConsts.TopUpPaymentItemType)
            .ToList();
        foreach (var item in items)
        {
            var accountId = Guid.Parse(item.ItemKey);
            using var currentTenant = _currentTenant.Change(payment.TenantId);
            var account = await _accountRepository.GetAsync(accountId);
            account.SetPendingTopUpPaymentId(payment.Id);
            await _accountRepository.UpdateAsync(account, true);
        }
    }
}