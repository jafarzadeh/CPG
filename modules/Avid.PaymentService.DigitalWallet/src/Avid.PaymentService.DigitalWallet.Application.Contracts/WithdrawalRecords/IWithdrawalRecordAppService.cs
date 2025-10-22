using System;
using Avid.PaymentService.DigitalWallet.WithdrawalRecords.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRecords;

public interface
    IWithdrawalRecordAppService : IReadOnlyAppService<WithdrawalRecordDto, Guid, PagedAndSortedResultRequestDto>
{
}