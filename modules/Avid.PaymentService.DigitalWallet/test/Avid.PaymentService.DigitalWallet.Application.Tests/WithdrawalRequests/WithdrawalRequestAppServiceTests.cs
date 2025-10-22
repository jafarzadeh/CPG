namespace Avid.PaymentService.DigitalWallet.WithdrawalRequests;

public class WithdrawalRequestAppServiceTests : DigitalWalletApplicationTestBase
{
    private readonly IWithdrawalRequestAppService _withdrawalRequestAppService;

    public WithdrawalRequestAppServiceTests()
    {
        _withdrawalRequestAppService = GetRequiredService<IWithdrawalRequestAppService>();
    } /*        [Fact]        public async Task Test1()        {            // Arrange            // Act            // Assert        }        */
}