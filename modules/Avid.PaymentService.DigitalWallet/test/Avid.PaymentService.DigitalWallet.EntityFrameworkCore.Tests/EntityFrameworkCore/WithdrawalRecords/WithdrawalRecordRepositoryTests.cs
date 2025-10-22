using Avid.PaymentService.DigitalWallet.WithdrawalRecords;

namespace Avid.PaymentService.DigitalWallet.EntityFrameworkCore.WithdrawalRecords;

public class WithdrawalRecordRepositoryTests : DigitalWalletEntityFrameworkCoreTestBase
{
    private readonly IWithdrawalRecordRepository _withdrawalRecordRepository;

    public WithdrawalRecordRepositoryTests()
    {
        _withdrawalRecordRepository = GetRequiredService<IWithdrawalRecordRepository>();
    } /*        [Fact]        public async Task Test1()        {            await WithUnitOfWorkAsync(async () =>            {                // Arrange                // Act                //Assert            });        }        */
}