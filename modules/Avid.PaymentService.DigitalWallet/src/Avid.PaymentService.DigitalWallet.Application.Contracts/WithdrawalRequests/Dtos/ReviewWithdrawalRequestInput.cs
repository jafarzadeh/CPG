using System;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRequests.Dtos;

[Serializable]
public class ReviewWithdrawalRequestInput
{
    public bool IsApproved { get; set; }
}