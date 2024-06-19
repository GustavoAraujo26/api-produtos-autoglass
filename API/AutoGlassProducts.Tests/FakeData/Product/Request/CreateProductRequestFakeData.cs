using AutoBogus;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.Extensions;
using System;

namespace AutoGlassProducts.Tests.FakeData.Product.Request
{
    internal static class CreateProductRequestFakeData
    {
        internal static CreateProductRequest BuildValid()
        {
            var autoFaker = new AutoFaker<CreateProductRequest>();

            autoFaker.RuleFor(x => x.Description, y => y.Commerce.ProductName().Truncate(200));
            autoFaker.RuleFor(x => x.MadeOn, y => DateTime.Now);
            autoFaker.RuleFor(x => x.ExpiresAt, y => DateTime.Now.AddDays(5));
            autoFaker.RuleFor(x => x.SupplierId, y => y.Random.Number(1, 1000000));

            return autoFaker.Generate();
        }

        internal static CreateProductRequest BuildInvalid()
        {
            var date = DateTime.Now;

            var autoFaker = new AutoFaker<CreateProductRequest>();

            autoFaker.RuleFor(x => x.Description, y => y.Commerce.ProductName().Truncate(200));
            autoFaker.RuleFor(x => x.MadeOn, y => date);
            autoFaker.RuleFor(x => x.ExpiresAt, y => date);
            autoFaker.RuleFor(x => x.SupplierId, y => 0);

            return autoFaker.Generate();
        }
    }
}
