using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Avid.PaymentService.DigitalWallet.
    WithdrawalRequests;

/// <summary>
///     This entity will be created if a user requests to withdraw with the "Manual" withdrawal method.
/// </summary>
public class WithdrawalRequest : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    protected WithdrawalRequest()
    {
    }

    public WithdrawalRequest(Guid id, Guid? tenantId, Guid accountId, Guid accountUserId, decimal amount) : base(id)
    {
        TenantId = tenantId;
        AccountId = accountId;
        AccountUserId = accountUserId;
        Amount = amount;
    }

    public virtual Guid AccountId { get; protected set; }
    public virtual Guid AccountUserId { get; protected set; }
    public virtual decimal Amount { get; protected set; }
    public virtual DateTime? ReviewTime { get; protected set; }
    public virtual Guid? ReviewerUserId { get; protected set; }
    public virtual bool? IsApproved { get; protected set; }
    public virtual Guid? TenantId { get; protected set; }

    public void Review(DateTime reviewTime, Guid reviewerUserId, bool isApproved)
    {
        CheckReviewable();
        ReviewTime = reviewTime;
        ReviewerUserId = reviewerUserId;
        IsApproved = isApproved;
    }

    public void CheckReviewable()
    {
        if (ReviewTime.HasValue || ReviewerUserId.HasValue || IsApproved.HasValue)
            throw new WithdrawalRequestHasBeenReviewedException();
    }
}