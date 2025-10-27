using System;
using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class AnotherRefundIsInProgressException : BusinessException
{
    public AnotherRefundIsInProgressException(Guid paymentId) : base(PaymentServiceErrorCodes.AnotherRefundIsInProgress)
    {
        WithData("paymentId", paymentId);
    }
}