using Avid.PaymentService.DigitalWallet.WithdrawalRequests;

namespace Avid.PaymentService.DigitalWallet.EntityFrameworkCore.WithdrawalRequests;

public class WithdrawalRequestRepositoryTests : DigitalWalletEntityFrameworkCoreTestBase
{
    private readonly IWithdrawalRequestRepository _withdrawalRequestRepository;

    public WithdrawalRequestRepositoryTests()
    {
        _withdrawalRequestRepository = GetRequiredService<IWithdrawalRequestRepository>();
    } /*        [Fact]        public async Task Test1()        {            await WithUnitOfWorkAsync(async () =>            {                // Arrange                // Act                //Assert            });        }        */
}