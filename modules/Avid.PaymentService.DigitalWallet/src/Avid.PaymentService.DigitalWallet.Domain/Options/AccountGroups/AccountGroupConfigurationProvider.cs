using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace Avid.PaymentService.DigitalWallet.Options.AccountGroups;

public class AccountGroupConfigurationProvider : IAccountGroupConfigurationProvider, ITransientDependency
{
    private readonly PaymentServiceDigitalWalletOptions _options;

    public AccountGroupConfigurationProvider(IOptions<PaymentServiceDigitalWalletOptions> options)
    {
        _options = options.Value;
    }

    public AccountGroupConfiguration Get(string accountGroupName)
    {
        return _options.AccountGroups.GetConfiguration(accountGroupName);
    }
}