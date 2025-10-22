using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Avid.PaymentService.DigitalWallet.Accounts.Dtos;

[Serializable]
public class ChangeLockedBalanceInput : IValidatableObject
{
    public decimal ChangedLockedBalance { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (ChangedLockedBalance == decimal.Zero)
        {
            yield return new ValidationResult("The ChangedLockedBalance should not be zero!",
                new[] { "ChangedLockedBalance" });
        }
    }
}