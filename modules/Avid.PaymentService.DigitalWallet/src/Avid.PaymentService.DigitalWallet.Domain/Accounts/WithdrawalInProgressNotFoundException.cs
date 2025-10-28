using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class WithdrawalInProgressNotFoundException()
    : BusinessException(DigitalWalletErrorCodes.WithdrawalInProgressNotFound);