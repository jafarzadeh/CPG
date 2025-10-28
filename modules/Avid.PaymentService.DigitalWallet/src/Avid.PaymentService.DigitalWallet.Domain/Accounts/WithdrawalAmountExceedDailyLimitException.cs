using Volo.Abp;

namespace Avid.PaymentService.DigitalWallet.Accounts;

public class WithdrawalAmountExceedDailyLimitException()
    : BusinessException(DigitalWalletErrorCodes.WithdrawalAmountExceedDailyLimit);