using System;
using System.Threading.Tasks;
using Avid.PaymentService.Payments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Avid.PaymentService.Payments;

public interface IPaymentAppService :
    IReadOnlyAppService<
        PaymentDto,
        Guid,
        GetPaymentListInput>
{
    Task<ListResultDto<PaymentMethodDto>> GetListPaymentMethodAsync();

    Task<PaymentDto> PayAsync(Guid id, PayInput input);

    Task<PaymentDto> CreatePaymentAsync(CreatePaymentInput paymentInput);

    Task<PaymentDto> CancelAsync(Guid id);

    Task<PaymentDto> RefundRollbackAsync(Guid id);
}