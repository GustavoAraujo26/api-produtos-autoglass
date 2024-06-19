using AutoBogus;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;

namespace AutoGlassProducts.Tests.FakeData.Supplier.Request
{
    internal static class GetSupplierRequestFakeData
    {
        internal static GetSupplierRequest BuildValid()
        {
            var autoFaker = new AutoFaker<GetSupplierRequest>();

            autoFaker.RuleFor(x => x.Id, y => y.Random.Number(1, 1000000));

            return autoFaker.Generate();
        }

        internal static GetSupplierRequest BuildInvalid()
        {
            var autoFaker = new AutoFaker<GetSupplierRequest>();

            autoFaker.RuleFor(x => x.Id, y => 0);

            return autoFaker.Generate();
        }
    }
}
