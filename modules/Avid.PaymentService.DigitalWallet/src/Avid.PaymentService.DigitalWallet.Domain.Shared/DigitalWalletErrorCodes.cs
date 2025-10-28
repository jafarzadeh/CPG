namespace Avid.PaymentService.DigitalWallet;

public static class DigitalWalletErrorCodes
{
    public const string Namespace = "Avid.PaymentService.DigitalWallet";
    public const string AmountOverflow = Namespace + ":AmountOverflow";
    public const string AmountFieldOverflow = Namespace + ":AmountFieldOverflow";
    public const string InsufficientBalanceToLock = Namespace + ":InsufficientBalanceToLock";
    public const string LockedBalanceIsLessThenPendingWithdrawalAmount = Namespace + ":LockedBalanceIsLessThenPendingWithdrawalAmount";
    public const string UnknownWithdrawalMethod = Namespace + ":UnknownWithdrawalMethod";
    public const string WithdrawalAmountExceedDailyLimit = Namespace + ":WithdrawalAmountExceedDailyLimit";
    public const string WithdrawalInProgressNotFound = Namespace + ":WithdrawalInProgressNotFound";
    public const string WithdrawalIsAlreadyInProgress = Namespace + ":WithdrawalIsAlreadyInProgress";
}