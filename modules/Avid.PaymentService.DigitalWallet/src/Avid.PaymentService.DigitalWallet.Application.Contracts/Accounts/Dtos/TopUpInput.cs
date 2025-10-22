using System;

namespace Avid.PaymentService.DigitalWallet.Accounts.Dtos;

[Serializable]
public class TopUpInput
{
    public string PaymentMethod { get; set; }
    public decimal Amount { get; set; }
}