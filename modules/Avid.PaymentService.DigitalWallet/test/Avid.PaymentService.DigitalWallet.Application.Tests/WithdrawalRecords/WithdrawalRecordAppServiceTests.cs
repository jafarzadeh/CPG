namespace Avid.PaymentService.DigitalWallet.WithdrawalRecords;

public class WithdrawalRecordAppServiceTests : DigitalWalletApplicationTestBase
{
    private readonly IWithdrawalRecordAppService _withdrawalRecordAppService;

    public WithdrawalRecordAppServiceTests()
    {
        _withdrawalRecordAppService = GetRequiredService<IWithdrawalRecordAppService>();
    } /*        [Fact]        public async Task Test1()        {            // Arrange            // Act            // Assert        }        */
}