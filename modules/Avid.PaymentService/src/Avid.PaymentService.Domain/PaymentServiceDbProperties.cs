namespace Avid.PaymentService;

public static class PaymentServiceDbProperties
{
    public const string ConnectionStringName = "AvidPaymentService";
    public static string DbTablePrefix { get; set; } = string.Empty;

    public static string DbSchema { get; set; } = "PaymentService";
}