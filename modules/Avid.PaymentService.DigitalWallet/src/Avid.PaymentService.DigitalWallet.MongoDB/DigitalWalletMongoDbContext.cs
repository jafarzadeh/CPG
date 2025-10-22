using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Avid.PaymentService.DigitalWallet;

[ConnectionStringName(DigitalWalletDbProperties.ConnectionStringName)]
public class DigitalWalletMongoDbContext : AbpMongoDbContext, IDigitalWalletMongoDbContext
{
    /* Add mongo collections here. Example:         * public IMongoCollection<Question> Questions => Collection<Question>();         */
    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);
        modelBuilder.ConfigureDigitalWallet();
    }
}