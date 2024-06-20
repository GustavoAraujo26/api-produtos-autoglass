using AutoBogus;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using ArchitectureTools.Extensions;
using System;

namespace AutoGlassProducts.Tests.FakeData.Product.Request
{
    internal static class EditProductRequestFakeData
    {
        internal static EditProductRequest BuildValid(int? supplierId = null)
        {
            var autoFaker = new AutoFaker<EditProductRequest>();

            autoFaker.RuleFor(x => x.Id, y => y.Random.Number(1, 1000000));
            autoFaker.RuleFor(x => x.Description, y => y.Commerce.ProductName().Truncate(200));
            autoFaker.RuleFor(x => x.MadeOn, y => DateTime.Now);
            autoFaker.RuleFor(x => x.ExpiresAt, y => DateTime.Now.AddDays(5));

            if (supplierId.HasValue && supplierId.Value != 0)
                autoFaker.RuleFor(x => x.SupplierId, y => supplierId.Value);
            else
                autoFaker.RuleFor(x => x.SupplierId, y => y.Random.Number(1, 1000000));


            return autoFaker.Generate();
        }

        internal static EditProductRequest BuildInvalid()
        {
            var date = DateTime.Now;

            var autoFaker = new AutoFaker<EditProductRequest>();

            autoFaker.RuleFor(x => x.Id, y => 0);
            autoFaker.RuleFor(x => x.Description, y => y.Commerce.ProductName().Truncate(200));
            autoFaker.RuleFor(x => x.MadeOn, y => date);
            autoFaker.RuleFor(x => x.ExpiresAt, y => date);
            autoFaker.RuleFor(x => x.SupplierId, y => 0);

            return autoFaker.Generate();
        }
    }
}
