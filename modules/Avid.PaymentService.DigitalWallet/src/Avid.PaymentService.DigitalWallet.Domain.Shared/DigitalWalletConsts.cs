namespace Avid.PaymentService.DigitalWallet;

public static class DigitalWalletConsts
{
    public const decimal AccountMinBalance = decimal.Zero;
    public const decimal AccountMaxBalance = 999999999999.99999999m;
    public const string ManualOperationPaymentMethod = "ManualOperation";
    public const string ChangeBalanceActionName = "ChangeBalance";
    public const string ChangeBalancePaymentMethod = ManualOperationPaymentMethod;
    public const string PaymentActionName = "Payment";
    public const string RefundActionName = "Refund";
    public const string TopUpActionName = "TopUp";
    public const string WithdrawalActionName = "Withdrawal";
    public const string TopUpPaymentItemType = "AvidPaymentServiceDigitalWalletTopUp";
    public const string PaymentAccountIdPropertyName = "AccountId";
}