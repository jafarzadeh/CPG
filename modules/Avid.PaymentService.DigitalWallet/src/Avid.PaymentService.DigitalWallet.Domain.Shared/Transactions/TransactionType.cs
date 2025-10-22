using System;

namespace Avid.PaymentService.DigitalWallet.Transactions;

[Flags]
public enum TransactionType
{
    Debit = 1,
    Credit = 2
}