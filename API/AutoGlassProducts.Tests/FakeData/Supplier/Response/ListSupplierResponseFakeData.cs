using ArchitectureTools.Pagination;
using AutoBogus;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using AutoGlassProducts.Tests.FakeData.Supplier.DTO;

namespace AutoGlassProducts.Tests.FakeData.Supplier.Response
{
    internal static class ListSupplierResponseFakeData
    {
        internal static ListSupplierResponse Build()
        {
            var autoFaker = new AutoFaker<ListSupplierResponse>();

            autoFaker.RuleFor(x => x.Suppliers, y => SupplierDTOFakeData.Build(5));
            autoFaker.RuleFor(x => x.Page, y => Page.Create(y.Random.Number(1, 10),
                y.Random.Number(10, 100), y.Random.Number(1000, 10000)));

            return autoFaker.Generate();
        }
    }
}
