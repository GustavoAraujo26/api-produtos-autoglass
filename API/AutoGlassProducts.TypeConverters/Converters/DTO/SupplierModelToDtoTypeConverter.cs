using ArchitectureTools.Extensions;
using AutoGlassProducts.Domain.DTO.Supplier;
using AutoGlassProducts.Domain.Models;
using AutoMapper;
using System.Collections.Generic;

namespace AutoGlassProducts.TypeConverters.Converters.DTO
{
    internal class SupplierModelToDtoTypeConverter : ITypeConverter<List<SupplierModel>, List<SupplierDTO>>
    {
        public List<SupplierDTO> Convert(List<SupplierModel> source, List<SupplierDTO> destination, ResolutionContext context)
        {
            List<SupplierDTO> result = new List<SupplierDTO>();

            foreach (var item in source)
                result.Add(new SupplierDTO(item.Id, item.Document, item.Description, item.Situation.GetData()));

            return result;
        }
    }
}
