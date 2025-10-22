namespace Avid.PaymentService.DigitalWallet.Options.AccountGroups;

public interface IAccountGroupConfigurationProvider
{
    AccountGroupConfiguration Get(string accountGroupName);
}