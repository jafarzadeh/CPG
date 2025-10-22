using AutoMapper;
using Avid.PaymentService.Payments;
using Avid.PaymentService.Payments.Dtos;
using Avid.PaymentService.Refunds;
using Avid.PaymentService.Refunds.Dtos;
using RefundDto = Avid.PaymentService.Refunds.Dtos.RefundDto;

namespace Avid.PaymentService;

public class PaymentServiceApplicationAutoMapperProfile : Profile
{
    public PaymentServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Payment, PaymentDto>().MapExtraProperties();
        CreateMap<PaymentItem, PaymentItemDto>().MapExtraProperties();
        CreateMap<Refund, RefundDto>().MapExtraProperties();
        CreateMap<RefundItem, RefundItemDto>().MapExtraProperties();
    }
}