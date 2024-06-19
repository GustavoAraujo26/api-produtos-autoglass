using AutoGlassProducts.Domain.Entities;
using AutoGlassProducts.Domain.Models;
using AutoMapper;

namespace AutoGlassProducts.TypeConverters.Converters.Models
{
    internal class SupplierModelTypeConverter : ITypeConverter<Supplier, SupplierModel>
    {
        public SupplierModel Convert(Supplier source, SupplierModel destination, ResolutionContext context) =>
            new SupplierModel(source.Id, source.Document, source.Description, source.Situation);
    }
}
