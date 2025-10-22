using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Avid.PaymentService.DigitalWallet;

public static class DigitalWalletMongoDbContextExtensions
{
    public static void ConfigureDigitalWallet(this IMongoModelBuilder builder,
        Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
    {
        Check.NotNull(builder, nameof(builder));
        var options = new DigitalWalletMongoModelBuilderConfigurationOptions(DigitalWalletDbProperties.DbTablePrefix);
        optionsAction?.Invoke(options);
    }
}