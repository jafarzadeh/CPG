using System;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.WithdrawalRecords.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Avid.PaymentService.DigitalWallet.WithdrawalRecords;

[RemoteService(Name = PaymentServiceRemoteServiceConsts.RemoteServiceName)]
[Route("/api/payment-service/digitalWallet/withdrawal-record")]
public class WithdrawalRecordController : DigitalWalletController, IWithdrawalRecordAppService
{
    private readonly IWithdrawalRecordAppService _service;

    public WithdrawalRecordController(IWithdrawalRecordAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{id}")]
    public Task<WithdrawalRecordDto> GetAsync(Guid id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    public Task<PagedResultDto<WithdrawalRecordDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return _service.GetListAsync(input);
    }
}