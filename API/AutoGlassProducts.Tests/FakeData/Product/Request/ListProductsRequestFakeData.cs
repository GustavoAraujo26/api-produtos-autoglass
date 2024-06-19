using ArchitectureTools.Period;
using AutoBogus;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.Enums;
using AutoGlassProducts.Domain.Extensions;
using System;

namespace AutoGlassProducts.Tests.FakeData.Product.Request
{
    internal static class ListProductsRequestFakeData
    {
        internal static ListProductsRequest BuildValid()
        {
            var autoFaker = new AutoFaker<ListProductsRequest>();

            autoFaker.RuleFor(x => x.DescriptionTrack, y => y.Commerce.ProductName().Truncate(200));
            autoFaker.RuleFor(x => x.ProductSituation, y => y.Random.Enum<Situation>());
            autoFaker.RuleFor(x => x.MadePeriod, y => new PeriodRange(DateTime.Now, DateTime.Now.AddYears(1)));
            autoFaker.RuleFor(x => x.ExpirationPeriod, y => new PeriodRange(DateTime.Now, DateTime.Now.AddYears(1)));
            autoFaker.RuleFor(x => x.SupplierDescriptionTrack, y => y.Company.CompanyName().Truncate(200));
            autoFaker.RuleFor(x => x.SupplierDocumentTrack, y => y.Random.ReplaceNumbers("########0001##"));
            autoFaker.RuleFor(x => x.SupplierSituation, y => y.Random.Enum<Situation>());
            autoFaker.RuleFor(x => x.Page, y => y.Random.Number(1, 10));
            autoFaker.RuleFor(x => x.PageSize, y => y.Random.Number(10, 100));

            return autoFaker.Generate();
        }

        internal static ListProductsRequest BuildInvalid()
        {
            var autoFaker = new AutoFaker<ListProductsRequest>();

            autoFaker.RuleFor(x => x.DescriptionTrack, y => y.Commerce.ProductName());
            autoFaker.RuleFor(x => x.ProductSituation, y => y.Random.Enum<Situation>());
            autoFaker.RuleFor(x => x.MadePeriod, y => new PeriodRange(DateTime.Now.AddYears(2), DateTime.Now.AddYears(1)));
            autoFaker.RuleFor(x => x.ExpirationPeriod, y => new PeriodRange(DateTime.Now.AddYears(2), DateTime.Now.AddYears(1)));
            autoFaker.RuleFor(x => x.SupplierDescriptionTrack, y => y.Company.CompanyName());
            autoFaker.RuleFor(x => x.SupplierDocumentTrack, y => y.Random.ReplaceNumbers("########0001######"));
            autoFaker.RuleFor(x => x.SupplierSituation, y => y.Random.Enum<Situation>());
            autoFaker.RuleFor(x => x.Page, y => 0);
            autoFaker.RuleFor(x => x.PageSize, y => 0);

            return autoFaker.Generate();
        }
    }
}
