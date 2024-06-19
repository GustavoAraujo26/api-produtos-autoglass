using AutoGlassProducts.Domain.DTO.Product;
using AutoGlassProducts.Domain.DTO.Supplier;
using AutoGlassProducts.Domain.Entities;
using AutoGlassProducts.TypeConverters.Converters.DTO;
using AutoMapper;

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
        }
    }
}
