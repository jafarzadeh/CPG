using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class WithdrawalIsAlreadyInProgressException()
    : BusinessException(DigitalWalletErrorCodes.WithdrawalIsAlreadyInProgress);