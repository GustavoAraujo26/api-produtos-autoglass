using ArchitectureTools.Pagination;
using AutoBogus;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Tests.FakeData.Product.DTO;

namespace AutoGlassProducts.Tests.FakeData.Product.Response
{
    internal static class ListProductResponseFakeData
    {
        internal static ListProductResponse Build()
        {
            var autoFaker = new AutoFaker<ListProductResponse>();

            autoFaker.RuleFor(x => x.Products, y => ProductDTOFakeData.Build(5));
            autoFaker.RuleFor(x => x.Page, y => Page.Create(y.Random.Number(1, 10), 
                y.Random.Number(10, 100), y.Random.Number(1000, 10000)));

            return autoFaker.Generate();
        }
    }
}
