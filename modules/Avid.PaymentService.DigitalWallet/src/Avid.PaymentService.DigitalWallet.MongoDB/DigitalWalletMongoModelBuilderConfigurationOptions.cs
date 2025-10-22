using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Avid.PaymentService.DigitalWallet;

public class DigitalWalletMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
{
    public DigitalWalletMongoModelBuilderConfigurationOptions([NotNull] string collectionPrefix = "") : base(
        collectionPrefix)
    {
    }
}