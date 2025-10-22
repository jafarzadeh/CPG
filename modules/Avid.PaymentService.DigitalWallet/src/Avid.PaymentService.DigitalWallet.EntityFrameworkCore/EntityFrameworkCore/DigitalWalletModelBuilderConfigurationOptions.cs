using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Avid.PaymentService.DigitalWallet.EntityFrameworkCore;

public class DigitalWalletModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
{
    public DigitalWalletModelBuilderConfigurationOptions([NotNull] string tablePrefix = "",
        [CanBeNull] string schema = null) : base(tablePrefix, schema)
    {
    }
}