using System.Threading.Tasks;
using Xunit;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class AccountAppServiceTests : DigitalWalletApplicationTestBase
{
    private readonly IAccountAppService _accountAppService;

    public AccountAppServiceTests()
    {
        _accountAppService = GetRequiredService<IAccountAppService>();
    }

    [Fact]
    public async Task Test1()
    {
        // Arrange
        //  Act
        //  Assert
    }
}