namespace Avid.PaymentService.DigitalWallet.Options.WithdrawalMethods;

public interface IWithdrawalMethodConfigurationProvider
{
    WithdrawalMethodConfiguration Get(string withdrawalMethodName);
}