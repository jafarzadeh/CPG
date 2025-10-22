using System;
using System.Threading.Tasks;
using Avid.PaymentService.Payments;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Avid.PaymentService.EntityFrameworkCore.Payments;

public class PaymentRepositoryTests : PaymentServiceEntityFrameworkCoreTestBase
{
    private readonly IRepository<Payment, Guid> _paymentRepository;

    public PaymentRepositoryTests()
    {
        _paymentRepository = GetRequiredService<IRepository<Payment, Guid>>();
    }

    [Fact]
    public async Task Test1()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            // Arrange

            // Act

            //Assert
        });
    }
}