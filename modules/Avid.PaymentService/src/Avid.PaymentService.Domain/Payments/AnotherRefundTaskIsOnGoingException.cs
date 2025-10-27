using System;
using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class AnotherRefundTaskIsOnGoingException : BusinessException
{
    public AnotherRefundTaskIsOnGoingException(Guid id)
        : base(PaymentServiceErrorCodes.AnotherRefundTaskIsOnGoing)
    {
        WithData("id", id);
    }
}