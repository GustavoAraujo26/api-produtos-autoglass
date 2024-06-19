using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.Entities;
using AutoGlassProducts.Domain.Models;
using AutoGlassProducts.TypeConverters.Converters.Entities;
using AutoMapper;
using System;

namespace AutoGlassProducts.TypeConverters.Profiles
{
    internal class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<ProductModel, Product>()
                .ConvertUsing<ProductModelToEntityConverter>();

            CreateMap<CreateProductRequest, Product>()
                .ConvertUsing<ProductCreationRequestToEntityConverter>();

            CreateMap<Tuple<EditProductRequest, Product>, Product>()
                .ConvertUsing<ProductEditRequestToEntityConverter>();

            CreateMap<SupplierModel, Supplier>()
                .ConvertUsing<SupplierModelToEntityTypeConverter>();

            CreateMap<CreateSupplierRequest, Supplier>()
                .ConvertUsing<SupplierCreationToEntityTypeConverter>();

            CreateMap<Tuple<EditSupplierRequest, Supplier>, Supplier>()
                .ConvertUsing<SupplierEditToEntityTypeConverter>();
        }
    }
}
