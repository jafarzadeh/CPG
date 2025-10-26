using Microsoft.EntityFrameworkCore;
using System;
using PaymentServiceSample.Enums;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;
using static PaymentServiceSample.PaymentServiceSampleConsts.ExtraProperties.IdentityUser;

namespace PaymentServiceSample.EntityFrameworkCore;

public static class PaymentServiceSampleEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
            ObjectExtensionManager.Instance.AddOrUpdate<IdentityUser>(o =>
            {
                o.MapEfCoreProperty<string>(NationalCode, (tb, b) =>
                {
                    tb.HasIndex(NationalCode, nameof(IdentityUser.TenantId))
                        .IsUnique();

                    b.HasMaxLength(10)
                        .HasDefaultValue(null);
                });

                o.MapEfCoreProperty<string>("IdCode", (_, b) =>
                {
                    b.HasMaxLength(100)
                        .HasDefaultValue(null);
                });

                o.MapEfCoreProperty<Province>("ProvinceId", (_, _) => { });

                o.MapEfCoreProperty<string>("City", (_, b) =>
                {
                    b.HasMaxLength(100)
                        .HasDefaultValue(null);
                });

                o.MapEfCoreProperty<string>("Address", (_, b) => { b.HasDefaultValue(null); });

                o.MapEfCoreProperty<string>("ZipCode", (_, b) =>
                {
                    b.HasMaxLength(10)
                        .HasDefaultValue(null);
                });

                o.MapEfCoreProperty<string>("FatherName", (_, b) =>
                {
                    b.HasMaxLength(50)
                        .HasDefaultValue(null);
                });

                o.MapEfCoreProperty<DateOnly?>("BirthDate", (_, b) => { b.HasDefaultValue(null); });
            });
        });
    }
}