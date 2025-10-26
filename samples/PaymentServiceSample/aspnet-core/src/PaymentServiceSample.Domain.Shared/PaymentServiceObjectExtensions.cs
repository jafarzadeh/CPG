using System;
using System.ComponentModel.DataAnnotations;
using PaymentServiceSample.Enums;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace PaymentServiceSample
{
    public static class PaymentServiceObjectExtensions
    {
        private static readonly OneTimeRunner OneTimeRunner = new();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                ObjectExtensionManager.Instance.Modules()
                    .ConfigureIdentity(c =>
                    {
                        c.ConfigureUser(u =>
                        {
                            u.AddOrUpdateProperty<string>("NationalCode",
                                o => { o.Attributes.Add(new StringLengthAttribute(10)); });

                            u.AddOrUpdateProperty<string>("IdCode",
                                o => { o.Attributes.Add(new StringLengthAttribute(100)); });

                            u.AddOrUpdateProperty<Province>("ProvinceId");

                            u.AddOrUpdateProperty<string>("City",
                                o => { o.Attributes.Add(new StringLengthAttribute(100)); });

                            u.AddOrUpdateProperty<string>("Address");

                            u.AddOrUpdateProperty<string>("ZipCode",
                                o => { o.Attributes.Add(new StringLengthAttribute(10)); });

                            u.AddOrUpdateProperty<string>("FatherName",
                                o => { o.Attributes.Add(new StringLengthAttribute(50)); });

                            u.AddOrUpdateProperty<DateOnly>("BirthDate",
                                o => { o.DefaultValue = DateOnly.FromDateTime(DateTime.Now); });

                        });
                    });
            });
        }
    }
}
