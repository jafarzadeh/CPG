using System.Threading.Tasks;
using Xunit;

namespace Avid.PaymentService.DigitalWallet.Transactions;

public class TransactionAppServiceTests : DigitalWalletApplicationTestBase
{
    private readonly ITransactionAppService _transactionAppService;

    public TransactionAppServiceTests()
    {
        _transactionAppService = GetRequiredService<ITransactionAppService>();
    }

    [Fact]
    public async Task Test1()
    {
        //Arrange
        // Act
        // Assert
    }
}