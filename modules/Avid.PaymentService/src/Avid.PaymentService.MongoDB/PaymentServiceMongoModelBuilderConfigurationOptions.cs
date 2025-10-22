using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Avid.PaymentService;

public class PaymentServiceMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
{
    public PaymentServiceMongoModelBuilderConfigurationOptions(
        [NotNull] string collectionPrefix = "")
        : base(collectionPrefix)
    {
    }
}