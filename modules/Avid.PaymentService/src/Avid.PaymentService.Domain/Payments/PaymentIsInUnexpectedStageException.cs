using System;
using Volo.Abp;

namespace Avid.PaymentService.Payments;

public class PaymentIsInUnexpectedStageException : BusinessException
{
    public PaymentIsInUnexpectedStageException(Guid id) : base(message: $"Payment ({id}) is in unexpected stage.")
    {
    }
}