using Avid.PaymentService.DigitalWallet.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Avid.PaymentService.DigitalWallet;

/* Domain tests are configured to use the EF Core provider.     * You can switch to MongoDB, however your domain tests should be     * database independent anyway.     */
[DependsOn(typeof(DigitalWalletEntityFrameworkCoreTestModule))]
public class DigitalWalletDomainTestModule : AbpModule
{
}