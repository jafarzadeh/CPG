using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace Avid.PaymentService.DigitalWallet.Options.WithdrawalMethods;

public class WithdrawalMethodConfigurationProvider : IWithdrawalMethodConfigurationProvider, ITransientDependency
{
    private readonly PaymentServiceDigitalWalletOptions _options;

    public WithdrawalMethodConfigurationProvider(IOptions<PaymentServiceDigitalWalletOptions> options)
    {
        _options = options.Value;
    }

    public WithdrawalMethodConfiguration Get(string withdrawalMethodName)
    {
        return _options.WithdrawalMethods.GetConfiguration(withdrawalMethodName);
    }
}