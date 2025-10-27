using System;
using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class InvalidRefundAmountException : BusinessException
{
    public InvalidRefundAmountException(Guid id, decimal refundAmount)
        : base(PaymentServiceErrorCodes.InvalidRefundAmount)
    {
        WithData("refundAmount", refundAmount);
        WithData("id", id);
    }
}