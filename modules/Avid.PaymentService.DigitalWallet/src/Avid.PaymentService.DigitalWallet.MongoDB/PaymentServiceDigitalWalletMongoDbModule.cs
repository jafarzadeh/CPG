using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Avid.PaymentService.DigitalWallet;

[DependsOn(typeof(PaymentServiceDigitalWalletDomainModule), typeof(AbpMongoDbModule))]
public class PaymentServiceDigitalWalletMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<DigitalWalletMongoDbContext>(options =>
        {
            /* Add custom repositories here. Example:                 * options.AddRepository<Question, MongoQuestionRepository>();                 */
        });
    }
}