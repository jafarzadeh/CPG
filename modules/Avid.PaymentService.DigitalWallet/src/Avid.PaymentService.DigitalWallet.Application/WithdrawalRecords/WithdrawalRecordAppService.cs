using System;
using Avid.PaymentService.DigitalWallet.Permissions;
using Avid.PaymentService.DigitalWallet.WithdrawalRecords.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRecords;

public class WithdrawalRecordAppService :
    ReadOnlyAppService<WithdrawalRecord, WithdrawalRecordDto, Guid, PagedAndSortedResultRequestDto>,
    IWithdrawalRecordAppService
{
    private readonly IWithdrawalRecordRepository _repository;

    public WithdrawalRecordAppService(IWithdrawalRecordRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override string GetPolicyName { get; set; } = DigitalWalletPermissions.WithdrawalRecord.Default;
    protected override string GetListPolicyName { get; set; } = DigitalWalletPermissions.WithdrawalRecord.Default;
}