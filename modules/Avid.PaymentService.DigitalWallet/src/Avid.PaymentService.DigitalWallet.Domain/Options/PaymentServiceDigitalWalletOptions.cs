using Avid.PaymentService.DigitalWallet.Options.AccountGroups;
using Avid.PaymentService.DigitalWallet.Options.WithdrawalMethods;

namespace Avid.PaymentService.DigitalWallet.Options;

public class PaymentServiceDigitalWalletOptions
{
    public PaymentServiceDigitalWalletOptions()
    {
        AccountGroups = new AccountGroupConfigurations();
        WithdrawalMethods = new WithdrawalMethodConfigurations();
    }

    public AccountGroupConfigurations AccountGroups { get; }
    public WithdrawalMethodConfigurations WithdrawalMethods { get; }
}