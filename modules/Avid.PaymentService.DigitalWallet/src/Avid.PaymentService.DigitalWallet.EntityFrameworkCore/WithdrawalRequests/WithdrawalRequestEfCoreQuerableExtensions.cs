using System.Linq;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRequests;

public static class WithdrawalRequestEfCoreQueryableExtensions
{
    public static IQueryable<WithdrawalRequest> IncludeDetails(this IQueryable<WithdrawalRequest> queryable,
        bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable // .Include(x => x.xxx) // TODO: AbpHelper generated
            ;
    }
}