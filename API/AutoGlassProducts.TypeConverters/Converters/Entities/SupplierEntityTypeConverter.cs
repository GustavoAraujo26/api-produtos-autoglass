using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.Entities;
using AutoGlassProducts.Domain.Models;
using AutoMapper;
using System;

namespace AutoGlassProducts.TypeConverters.Converters.Entities
{
    internal class SupplierModelToEntityTypeConverter : ITypeConverter<SupplierModel, Supplier>
    {
        public Supplier Convert(SupplierModel source, Supplier destination, ResolutionContext context) =>
            new Supplier(source.Document, source.Description, source.Situation, source.Id);
    }

    internal class SupplierCreationToEntityTypeConverter : ITypeConverter<CreateSupplierRequest, Supplier>
    {
        public Supplier Convert(CreateSupplierRequest source, Supplier destination, ResolutionContext context) =>
            Supplier.Create(source.Document, source.Description);
    }

    internal class SupplierEditToEntityTypeConverter : ITypeConverter<Tuple<EditSupplierRequest, Supplier>, Supplier>
    {
        public Supplier Convert(Tuple<EditSupplierRequest, Supplier> source, Supplier destination, ResolutionContext context)
        {
            var newSupplier = Supplier.Copy(source.Item2);
            newSupplier.UpdateBasicData(source.Item1.Document, source.Item1.Description);

            return newSupplier;
        }
    }
}
