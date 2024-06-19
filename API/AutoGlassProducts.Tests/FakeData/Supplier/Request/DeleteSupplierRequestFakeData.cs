using AutoBogus;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;

namespace AutoGlassProducts.Tests.FakeData.Supplier.Request
{
    internal static class DeleteSupplierRequestFakeData
    {
        internal static DeleteSupplierRequest BuildValid()
        {
            var autoFaker = new AutoFaker<DeleteSupplierRequest>();

            autoFaker.RuleFor(x => x.Id, y => y.Random.Number(1, 1000000));

            return autoFaker.Generate();
        }

        internal static DeleteSupplierRequest BuildInvalid()
        {
            var autoFaker = new AutoFaker<DeleteSupplierRequest>();

            autoFaker.RuleFor(x => x.Id, y => 0);

            return autoFaker.Generate();
        }
    }
}
