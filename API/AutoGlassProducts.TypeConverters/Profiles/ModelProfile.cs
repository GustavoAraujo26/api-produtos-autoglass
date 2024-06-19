using AutoGlassProducts.Domain.Entities;
using AutoGlassProducts.Domain.Models;
using AutoGlassProducts.TypeConverters.Converters.Models;
using AutoMapper;

namespace AutoGlassProducts.TypeConverters.Profiles
{
    internal class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Product, ProductModel>()
                .ConvertUsing<ProductModelTypeConverter>();

            CreateMap<Supplier, SupplierModel>()
                .ConvertUsing<SupplierModelTypeConverter>();
        }
    }
}
