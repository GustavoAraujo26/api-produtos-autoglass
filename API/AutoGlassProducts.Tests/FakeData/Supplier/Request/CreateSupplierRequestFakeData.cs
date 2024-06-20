using AutoBogus;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using ArchitectureTools.Extensions;

namespace AutoGlassProducts.Tests.FakeData.Supplier.Request
{
    internal static class CreateSupplierRequestFakeData
    {
        internal static CreateSupplierRequest BuildValid()
        {
            var autoFaker = new AutoFaker<CreateSupplierRequest>();

            autoFaker.RuleFor(x => x.Description, y => y.Company.CompanyName().Truncate(200));
            autoFaker.RuleFor(x => x.Document, y => y.Random.ReplaceNumbers("########0001##"));

            return autoFaker.Generate();
        }

        internal static CreateSupplierRequest BuildInvalid()
        {
            var autoFaker = new AutoFaker<CreateSupplierRequest>();

            autoFaker.RuleFor(x => x.Description, y => y.Lorem.Paragraph());
            autoFaker.RuleFor(x => x.Document, y => y.Random.ReplaceNumbers("########0001#######"));

            return autoFaker.Generate();
        }
    }
}
