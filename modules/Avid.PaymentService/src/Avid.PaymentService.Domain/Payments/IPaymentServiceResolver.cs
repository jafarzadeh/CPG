using System;
using System.Collections.Generic;

namespace Avid.PaymentService.Payments;

public interface IPaymentServiceResolver
{
    List<string> GetPaymentMethods();

    Type GetProviderTypeOrDefault(string paymentMethod);
}