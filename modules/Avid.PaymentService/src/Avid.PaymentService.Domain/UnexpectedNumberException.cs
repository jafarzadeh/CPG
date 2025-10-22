using Volo.Abp;

namespace Avid.PaymentService;

public class UnexpectedNumberException : BusinessException
{
    public UnexpectedNumberException(decimal number) : base(message: $"The number ({number}) is not expected.")
    {
    }
}