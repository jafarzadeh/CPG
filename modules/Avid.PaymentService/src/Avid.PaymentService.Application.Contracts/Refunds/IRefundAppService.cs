using System;
using Avid.PaymentService.Refunds.Dtos;
using Volo.Abp.Application.Services;

namespace Avid.PaymentService.Refunds;

public interface IRefundAppService :
    IReadOnlyAppService<
        RefundDto,
        Guid,
        GetRefundListInput>
{
}