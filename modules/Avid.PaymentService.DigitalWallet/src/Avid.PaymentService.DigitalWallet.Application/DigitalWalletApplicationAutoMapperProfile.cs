using AutoMapper;
using Avid.PaymentService.DigitalWallet.Accounts;
using Avid.PaymentService.DigitalWallet.Accounts.Dtos;
using Avid.PaymentService.DigitalWallet.Transactions;
using Avid.PaymentService.DigitalWallet.Transactions.Dtos;
using Avid.PaymentService.DigitalWallet.WithdrawalRecords;
using Avid.PaymentService.DigitalWallet.WithdrawalRecords.Dtos;
using Avid.PaymentService.DigitalWallet.WithdrawalRequests;
using Avid.PaymentService.DigitalWallet.WithdrawalRequests.Dtos;

namespace Avid.PaymentService.DigitalWallet;

public class DigitalWalletApplicationAutoMapperProfile : Profile
{
    public DigitalWalletApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.             * Alternatively, you can split your mapping configurations             * into multiple profile classes for a better organization. */
        CreateMap<Account, AccountDto>().MapExtraProperties();
        CreateMap<Transaction, TransactionDto>().MapExtraProperties();
        CreateMap<WithdrawalRecord, WithdrawalRecordDto>();
        CreateMap<WithdrawalRequest, WithdrawalRequestDto>();
    }
}