using AutoBogus;
using AutoGlassProducts.Domain.DTO.Product.Requests;

namespace AutoGlassProducts.Tests.FakeData.Product.Request
{
    internal static class GetProductRequestFakeData
    {
        internal static GetProductRequest BuildValid()
        {
            var autoFaker = new AutoFaker<GetProductRequest>();

            autoFaker.RuleFor(x => x.Id, y => y.Random.Number(1, 1000000));

            return autoFaker.Generate();
        }

        internal static GetProductRequest BuildInvalid()
        {
            var autoFaker = new AutoFaker<GetProductRequest>();

            autoFaker.RuleFor(x => x.Id, y => 0);

            return autoFaker.Generate();
        }
    }
}
