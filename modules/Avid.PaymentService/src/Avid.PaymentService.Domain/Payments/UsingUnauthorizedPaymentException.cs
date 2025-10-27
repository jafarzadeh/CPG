using System;
using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class UsingUnauthorizedPaymentException : BusinessException
{
    public UsingUnauthorizedPaymentException(Guid userId, Guid paymentId)
        : base(PaymentServiceErrorCodes.UsingUnauthorizedPayment)
    {
        WithData("userId", userId);
        WithData("paymentId", paymentId);
    }
}