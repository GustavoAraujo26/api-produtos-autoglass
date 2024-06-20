using AutoBogus;
using ArchitectureTools.Extensions;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;

namespace AutoGlassProducts.Tests.FakeData.Supplier.Response
{
    internal static class SupplierResponseFakeData
    {
        internal static SupplierResponse Build()
        {
            var autoFaker = new AutoFaker<SupplierResponse>();

            autoFaker.RuleFor(x => x.Id, y => y.Random.Number(1, 1000000));
            autoFaker.RuleFor(x => x.Description, y => y.Company.CompanyName().Truncate(200));

            return autoFaker.Generate();
        }
    }
}
