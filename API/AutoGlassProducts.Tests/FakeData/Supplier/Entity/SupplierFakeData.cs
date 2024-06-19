using AutoBogus;
using AutoGlassProducts.Domain.Enums;
using AutoGlassProducts.Domain.Extensions;

namespace AutoGlassProducts.Tests.FakeData.Supplier.Entity
{
    internal static class SupplierFakeData
    {
        internal static Domain.Entities.Supplier Build()
        {
            var autoFaker = new AutoFaker<Domain.Entities.Supplier>();

            autoFaker.RuleFor(x => x.Id, y => y.Random.Number(1, 1000000));
            autoFaker.RuleFor(x => x.Description, y => y.Company.CompanyName().Truncate(200));
            autoFaker.RuleFor(x => x.Document, y => y.Random.ReplaceNumbers("########0001##"));
            autoFaker.RuleFor(x => x.Situation, y => y.Random.Enum<Situation>());

            return autoFaker.Generate();
        }
    }
}
