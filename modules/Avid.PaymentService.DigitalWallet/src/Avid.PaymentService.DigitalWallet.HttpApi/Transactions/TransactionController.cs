using System;
using System.Threading.Tasks;
using Avid.PaymentService.DigitalWallet.Transactions.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Avid.PaymentService.DigitalWallet.Transactions;

[RemoteService(Name = PaymentServiceRemoteServiceConsts.RemoteServiceName)]
[Route("/api/payment-service/digitalWallet/transaction")]
public class TransactionController : DigitalWalletController, ITransactionAppService
{
    private readonly ITransactionAppService _service;

    public TransactionController(ITransactionAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{id}")]
    public virtual Task<TransactionDto> GetAsync(Guid id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    public virtual Task<PagedResultDto<TransactionDto>> GetListAsync(GetTransactionListInput input)
    {
        return _service.GetListAsync(input);
    }
}