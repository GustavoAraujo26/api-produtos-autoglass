using ArchitectureTools.Extensions;
using AutoGlassProducts.Domain.DTO.Product;
using AutoGlassProducts.Domain.DTO.Supplier;
using AutoGlassProducts.Domain.Entities;
using AutoMapper;

namespace AutoGlassProducts.TypeConverters.Converters.DTO
{
    internal class ProductDtoTypeConverter : ITypeConverter<Domain.Entities.Product, ProductDTO>
    {
        public ProductDTO Convert(Product source, ProductDTO destination, ResolutionContext context)
        {
            var supplier = context.Mapper.Map<SupplierDTO>(source.Supplier);

            return new ProductDTO(source.Id, source.Description, source.Situation.GetData(), 
                source.MadeOn, source.ExpiresAt, supplier);
        }
    }
}
