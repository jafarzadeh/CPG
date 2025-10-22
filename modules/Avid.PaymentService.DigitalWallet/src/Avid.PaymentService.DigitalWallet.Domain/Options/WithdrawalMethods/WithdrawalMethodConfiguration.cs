using System;

namespace Avid.PaymentService.DigitalWallet.Options.WithdrawalMethods;

public class WithdrawalMethodConfiguration
{
    public Type AccountWithdrawalProviderType { get; set; }
    public decimal? DailyMaximumWithdrawalAmountEachAccount { get; set; }
}