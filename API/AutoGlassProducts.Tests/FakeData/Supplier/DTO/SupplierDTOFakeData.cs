using ArchitectureTools.Extensions;
using AutoBogus;
using AutoGlassProducts.Domain.DTO.Supplier;
using AutoGlassProducts.Domain.Enums;
using AutoGlassProducts.Domain.Extensions;
using System.Collections.Generic;

namespace AutoGlassProducts.Tests.FakeData.Supplier.DTO
{
    internal static class SupplierDTOFakeData
    {
        internal static SupplierDTO Build() =>
            BuildFaker().Generate();

        internal static List<SupplierDTO> Build(int count) =>
            BuildFaker().Generate(count);

        private static AutoFaker<SupplierDTO> BuildFaker()
        {
            var autoFaker = new AutoFaker<SupplierDTO>();

            autoFaker.RuleFor(x => x.Id, y => y.Random.Number(1, 1000000));
            autoFaker.RuleFor(x => x.Description, y => y.Company.CompanyName().Truncate(200));
            autoFaker.RuleFor(x => x.Document, y => y.Random.ReplaceNumbers("########0001##"));
            autoFaker.RuleFor(x => x.Situation, y => y.Random.Enum<Situation>().GetData());

            return autoFaker;
        }
    }
}
