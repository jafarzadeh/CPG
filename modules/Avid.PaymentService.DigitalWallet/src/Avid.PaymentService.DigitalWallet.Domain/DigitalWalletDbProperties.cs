namespace Avid.PaymentService.DigitalWallet;

public static class DigitalWalletDbProperties
{
    public const string ConnectionStringName = "AvidPaymentServiceDigitalWallet";
    public static string DbTablePrefix { get; set; } = string.Empty;
    public static string DbSchema { get; set; } = "PaymentServiceDigitalWallet";
}