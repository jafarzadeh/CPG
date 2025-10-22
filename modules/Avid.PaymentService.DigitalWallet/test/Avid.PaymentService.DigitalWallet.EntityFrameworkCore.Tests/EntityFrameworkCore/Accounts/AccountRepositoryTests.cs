using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Accounts;
using Xunit;

namespace Avid.PaymentService.DigitalWallet.EntityFrameworkCore.Accounts;

public class AccountRepositoryTests : DigitalWalletEntityFrameworkCoreTestBase
{
    private readonly IAccountRepository _accountRepository;

    public AccountRepositoryTests()
    {
        _accountRepository = GetRequiredService<IAccountRepository>();
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