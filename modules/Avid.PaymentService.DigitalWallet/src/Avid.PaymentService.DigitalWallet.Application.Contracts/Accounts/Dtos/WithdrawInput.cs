using System;
using Volo.Abp.ObjectExtending;

namespace Avid.PaymentService.DigitalWallet.Accounts.Dtos;

[Serializable]
public class WithdrawInput : ExtensibleObject
{
    public string WithdrawalMethod { get; set; }
    public decimal Amount { get; set; }
}