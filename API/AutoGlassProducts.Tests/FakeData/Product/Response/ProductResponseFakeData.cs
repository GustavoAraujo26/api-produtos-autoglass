using AutoBogus;
using AutoGlassProducts.Domain.Extensions;
using AutoGlassProducts.Domain.DTO.Product.Responses;

namespace AutoGlassProducts.Tests.FakeData.Product.Response
{
    internal static class ProductResponseFakeData
    {
        internal static ProductResponse Build()
        {
            var autoFaker = new AutoFaker<ProductResponse>();

            autoFaker.RuleFor(x => x.Id, y => y.Random.Number(1, 1000000));
            autoFaker.RuleFor(x => x.Description, y => y.Commerce.ProductName().Truncate(200));

            return autoFaker.Generate();
        }
    }
}
