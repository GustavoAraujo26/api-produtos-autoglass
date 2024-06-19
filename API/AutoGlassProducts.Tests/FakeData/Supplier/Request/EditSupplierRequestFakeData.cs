using AutoBogus;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.Extensions;

namespace AutoGlassProducts.Tests.FakeData.Supplier.Request
{
    internal static class EditSupplierRequestFakeData
    {
        internal static EditSupplierRequest BuildValid()
        {
            var autoFaker = new AutoFaker<EditSupplierRequest>();

            autoFaker.RuleFor(x => x.Id, y => y.Random.Number(1, 1000000));
            autoFaker.RuleFor(x => x.Description, y => y.Company.CompanyName().Truncate(200));
            autoFaker.RuleFor(x => x.Document, y => y.Random.ReplaceNumbers("########0001##"));

            return autoFaker.Generate();
        }

        internal static EditSupplierRequest BuildInvalid()
        {
            var autoFaker = new AutoFaker<EditSupplierRequest>();

            autoFaker.RuleFor(x => x.Id, y => 0);
            autoFaker.RuleFor(x => x.Description, y => y.Lorem.Paragraph());
            autoFaker.RuleFor(x => x.Document, y => y.Random.ReplaceNumbers("########0001#######"));

            return autoFaker.Generate();
        }
    }
}
