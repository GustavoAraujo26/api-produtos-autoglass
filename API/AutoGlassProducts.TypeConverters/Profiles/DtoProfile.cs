using AutoGlassProducts.Domain.DTO.Product;
using AutoGlassProducts.Domain.DTO.Supplier;
using AutoGlassProducts.Domain.Entities;
using AutoGlassProducts.Domain.Models;
using AutoGlassProducts.TypeConverters.Converters.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AutoGlassProducts.TypeConverters.Profiles
{
    internal class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDTO>()
                .ConvertUsing<ProductDtoTypeConverter>();

            CreateMap<Supplier, SupplierDTO>()
                .ConvertUsing<SupplierDtoTypeConverter>();

            CreateMap<List<SupplierModel>, List<SupplierDTO>>()
                .ConvertUsing<SupplierModelToDtoTypeConverter>();

            CreateMap<List<Tuple<ProductModel, SupplierModel>>, List<ProductDTO>>()
                .ConvertUsing<ProductModelToDtoTypeConverter>();
        }
    }
}
