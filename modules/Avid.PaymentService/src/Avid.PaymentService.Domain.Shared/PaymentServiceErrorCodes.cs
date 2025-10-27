namespace Avid.PaymentService;

public static class PaymentServiceErrorCodes
{
    public const string AnotherRefundIsInProgress = "Avid.PaymentService:AnotherRefundIsInProgress";
    public const string AnotherRefundTaskIsOnGoing = "Avid.PaymentService:AnotherRefundTaskIsOnGoing";
    public const string CurrencyNotSupported = "Avid.PaymentService:CurrencyNotSupported";
    public const string DuplicatePaymentItemId = "Avid.PaymentService:DuplicatePaymentItemId";
    public const string DuplicatePaymentRequest = "Avid.PaymentService:DuplicatePaymentRequest";
    public const string InvalidRefundAmount = "Avid.PaymentService:InvalidRefundAmount";
    public const string PayeeAccountNotFound = "Avid.PaymentService:PayeeAccountNotFound";
    public const string PayeeConfigurationMissingValue = "Avid.PaymentService:PayeeConfigurationMissingValue";
    public const string PaymentAmountInvalid = "Avid.PaymentService:PaymentAmountInvalid";
    public const string PaymentIsInUnexpectedStage = "Avid.PaymentService:PaymentIsInUnexpectedStage";
    public const string UnknownPaymentMethod = "Avid.PaymentService:UnknownPaymentMethod";
    public const string UsingUnauthorizedPayment = "Avid.PaymentService:UsingUnauthorizedPayment";
}