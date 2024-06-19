using AutoGlassProducts.Domain.Entities;
using AutoGlassProducts.Domain.Models;
using AutoMapper;

namespace AutoGlassProducts.TypeConverters.Converters.Models
{
    internal class ProductModelTypeConverter : ITypeConverter<Product, ProductModel>
    {
        public ProductModel Convert(Product source, ProductModel destination, ResolutionContext context) =>
            new ProductModel(source.Id, source.Supplier.Id, source.Description, source.Situation, source.MadeOn, source.ExpiresAt);
    }
}
