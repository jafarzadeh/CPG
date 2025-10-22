/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */

namespace Avid.PaymentService;

public abstract class PaymentServiceDomainTestBase : PaymentServiceTestBase<PaymentServiceDomainTestModule>
{
}