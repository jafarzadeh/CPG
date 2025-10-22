using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Accounts;
using Avid.PaymentService.DigitalWallet.Options.AccountGroups;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace Avid.PaymentService.DigitalWallet;

public class DigitalWalletDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IAccountRepository _accountRepository;
    private readonly IGuidGenerator _guidGenerator;

    public DigitalWalletDataSeedContributor(IAccountRepository accountRepository, IGuidGenerator guidGenerator)
    {
        _accountRepository = accountRepository;
        _guidGenerator = guidGenerator;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        /* Instead of returning the Task.CompletedTask, you can insert your test data             * at this point!             */
        await _accountRepository.InsertAsync(
            new Account(DigitalWalletTestConsts.AccountId, null,
                AccountGroupNameAttribute.GetAccountGroupName<DefaultAccountGroup>(), DigitalWalletTestConsts.UserId,
                DigitalWalletTestConsts.AccountBaseBalance, 0m), true);
    }
}