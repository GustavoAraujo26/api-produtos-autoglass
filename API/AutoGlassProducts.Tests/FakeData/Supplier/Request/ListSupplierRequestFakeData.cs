using AutoBogus;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.Enums;
using AutoGlassProducts.Domain.Extensions;

namespace AutoGlassProducts.Tests.FakeData.Supplier.Request
{
    internal static class ListSupplierRequestFakeData
    {
        public static ListSupplierRequest BuildValid()
        {
            var autoFaker = new AutoFaker<ListSupplierRequest>();

            autoFaker.RuleFor(x => x.DescriptionTrack, y => y.Company.CompanyName().Truncate(200));
            autoFaker.RuleFor(x => x.DocumentTrack, y => y.Random.ReplaceNumbers("########0001##"));
            autoFaker.RuleFor(x => x.Situation, y => y.Random.Enum<Situation>());
            autoFaker.RuleFor(x => x.Page, y => y.Random.Number(1, 10));
            autoFaker.RuleFor(x => x.PageSize, y => y.Random.Number(10, 100));

            return autoFaker.Generate();
        }

        public static ListSupplierRequest BuildInvalid()
        {
            var autoFaker = new AutoFaker<ListSupplierRequest>();

            autoFaker.RuleFor(x => x.DescriptionTrack, y => y.Lorem.Paragraph());
            autoFaker.RuleFor(x => x.DocumentTrack, y => y.Random.ReplaceNumbers("########0001########"));
            autoFaker.RuleFor(x => x.Situation, y => y.Random.Enum<Situation>());
            autoFaker.RuleFor(x => x.Page, y => 0);
            autoFaker.RuleFor(x => x.PageSize, y => 0);

            return autoFaker.Generate();
        }
    }
}
