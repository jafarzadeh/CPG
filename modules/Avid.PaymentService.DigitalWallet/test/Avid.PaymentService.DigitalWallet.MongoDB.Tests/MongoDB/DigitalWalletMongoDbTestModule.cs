using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Avid.PaymentService.DigitalWallet.MongoDB;

[DependsOn(typeof(DigitalWalletTestBaseModule), typeof(PaymentServiceDigitalWalletMongoDbModule))]
public class DigitalWalletMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
        });
    }
}