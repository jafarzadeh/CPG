using System;
using System.Collections.Generic;
using Volo.Abp.ObjectExtending;

namespace Avid.PaymentService.Payments.Dtos
{
    public class CreatePaymentInput : ExtensibleObject
    {
        public Guid UserId { get; set; }

        public string PaymentMethod { get; set; }

        public List<CreatePaymentItemInput> PaymentItems { get; set; } = [];
    }

    public class CreatePaymentItemInput : ExtensibleObject
    {
        public string ItemType { get; set; }

        public string ItemKey { get; set; }

        public decimal OriginalPaymentAmount { get; set; }
    }
}
