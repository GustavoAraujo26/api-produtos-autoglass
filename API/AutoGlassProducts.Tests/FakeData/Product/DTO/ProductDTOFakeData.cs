using AutoBogus;
using AutoGlassProducts.Domain.DTO.Product;
using AutoGlassProducts.Domain.Extensions;
using AutoGlassProducts.Tests.FakeData.Supplier.DTO;
using System;
using System.Collections.Generic;

namespace AutoGlassProducts.Tests.FakeData.Product.DTO
{
    internal static class ProductDTOFakeData
    {
        internal static ProductDTO Build() =>
            BuildFaker().Generate();

        internal static List<ProductDTO> Build(int count) =>
            BuildFaker().Generate(count);

        private static AutoFaker<ProductDTO> BuildFaker()
        {
            var autoFaker = new AutoFaker<ProductDTO>();

            autoFaker.RuleFor(x => x.Id, y => y.Random.Number(1, 1000000));
            autoFaker.RuleFor(x => x.Description, y => y.Commerce.ProductName().Truncate(200));
            autoFaker.RuleFor(x => x.MadeOn, y => DateTime.Now);
            autoFaker.RuleFor(x => x.ExpiresAt, y => DateTime.Now.AddDays(5));
            autoFaker.RuleFor(x => x.Supplier, y => SupplierDTOFakeData.Build());

            return autoFaker;
        }
    }
}
