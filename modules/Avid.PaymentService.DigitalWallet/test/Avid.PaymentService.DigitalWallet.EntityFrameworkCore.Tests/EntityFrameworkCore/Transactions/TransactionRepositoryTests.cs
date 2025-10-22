using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Transactions;
using Xunit;

namespace Avid.PaymentService.DigitalWallet.EntityFrameworkCore.Transactions;

public class TransactionRepositoryTests : DigitalWalletEntityFrameworkCoreTestBase
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionRepositoryTests()
    {
        _transactionRepository = GetRequiredService<ITransactionRepository>();
    }

    [Fact]
    public async Task Test1()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            // Arrange
            // Act
            // Assert
        });
    }
}