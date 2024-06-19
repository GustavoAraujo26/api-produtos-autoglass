using AutoBogus;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;

namespace AutoGlassProducts.Tests.FakeData.Supplier.Request
{
    internal static class EnableSupplierRequestFakeData
    {
        internal static EnableSupplierRequest BuildValid()
        {
            var autoFaker = new AutoFaker<EnableSupplierRequest>();

            autoFaker.RuleFor(x => x.Id, y => y.Random.Number(1, 1000000));

            return autoFaker.Generate();
        }

        internal static EnableSupplierRequest BuildInvalid()
        {
            var autoFaker = new AutoFaker<EnableSupplierRequest>();

            autoFaker.RuleFor(x => x.Id, y => 0);

            return autoFaker.Generate();
        }
    }
}
