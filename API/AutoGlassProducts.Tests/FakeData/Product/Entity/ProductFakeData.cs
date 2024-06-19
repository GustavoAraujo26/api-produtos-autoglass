using AutoBogus;
using AutoGlassProducts.Domain.Extensions;
using AutoGlassProducts.Tests.FakeData.Supplier.Entity;
using System;

namespace AutoGlassProducts.Tests.FakeData.Product.Entity
{
    internal static class ProductFakeData
    {
        internal static Domain.Entities.Product BuildValid()
        {
            var autoFaker = new AutoFaker<Domain.Entities.Product>();

            autoFaker.RuleFor(x => x.Id, y => y.Random.Number(1, 1000000));
            autoFaker.RuleFor(x => x.Description, y => y.Commerce.ProductName().Truncate(200));
            autoFaker.RuleFor(x => x.MadeOn, y => DateTime.Now);
            autoFaker.RuleFor(x => x.ExpiresAt, y => DateTime.Now.AddDays(5));
            autoFaker.RuleFor(x => x.Supplier, y => SupplierFakeData.Build());

            return autoFaker.Generate();
        }
    }
}
