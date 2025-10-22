using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Avid.PaymentService.DigitalWallet;

[ConnectionStringName(DigitalWalletDbProperties.ConnectionStringName)]
public interface IDigitalWalletMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:         * IMongoCollection<Question> Questions { get; }         */
}