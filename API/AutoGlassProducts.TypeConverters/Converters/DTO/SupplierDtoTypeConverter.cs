using ArchitectureTools.Extensions;
using AutoGlassProducts.Domain.DTO.Supplier;
using AutoGlassProducts.Domain.Entities;
using AutoMapper;

namespace AutoGlassProducts.TypeConverters.Converters.DTO
{
    internal class SupplierDtoTypeConverter : ITypeConverter<Supplier, SupplierDTO>
    {
        public SupplierDTO Convert(Supplier source, SupplierDTO destination, ResolutionContext context) =>
            new SupplierDTO(source.Id, source.Document, source.Description, source.Situation.GetData());
    }
}
