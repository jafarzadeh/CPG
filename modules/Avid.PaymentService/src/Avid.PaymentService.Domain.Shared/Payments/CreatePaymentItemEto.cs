using Volo.Abp.ObjectExtending;

namespace Avid.PaymentService.Payments;

public class CreatePaymentItemEto : ExtensibleObject
{
    public string ItemType { get; set; }

    public string ItemKey { get; set; }

    public decimal OriginalPaymentAmount { get; set; }
}