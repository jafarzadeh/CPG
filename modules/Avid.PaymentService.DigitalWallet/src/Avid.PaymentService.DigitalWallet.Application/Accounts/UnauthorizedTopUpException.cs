using System;
using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class UnauthorizedTopUpException : BusinessException
{
    public UnauthorizedTopUpException(Guid accountId) : base(message: $"Cannot top up the account ({accountId}).")
    {
    }
}