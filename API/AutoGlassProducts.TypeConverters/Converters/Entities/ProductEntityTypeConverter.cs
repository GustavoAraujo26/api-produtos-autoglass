using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.Entities;
using AutoGlassProducts.Domain.Models;
using AutoMapper;
using System;

namespace AutoGlassProducts.TypeConverters.Converters.Entities
{
    internal class ProductModelToEntityConverter : ITypeConverter<ProductModel, Product>
    {
        public Product Convert(ProductModel source, Product destination, ResolutionContext context) =>
            new Product(source.Description, source.Situation, source.MadeOn, source.ExpiresAt, source.Id);
    }

    internal class ProductCreationRequestToEntityConverter : ITypeConverter<CreateProductRequest, Product>
    {
        public Product Convert(CreateProductRequest source, Product destination, ResolutionContext context) =>
            Product.Create(source.Description, source.MadeOn, source.ExpiresAt);
    }

    internal class ProductEditRequestToEntityConverter : ITypeConverter<Tuple<EditProductRequest, Product>, Product>
    {
        public Product Convert(Tuple<EditProductRequest, Product> source, Product destination, ResolutionContext context)
        {
            var newProduct = Product.Copy(source.Item2);
            newProduct.UpdateBasicData(source.Item1.Description, source.Item1.MadeOn, source.Item1.ExpiresAt);

            return newProduct;
        }
    }
}
