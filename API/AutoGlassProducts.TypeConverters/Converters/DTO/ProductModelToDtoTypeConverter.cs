using ArchitectureTools.Extensions;
using AutoGlassProducts.Domain.DTO.Product;
using AutoGlassProducts.Domain.DTO.Supplier;
using AutoGlassProducts.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoGlassProducts.TypeConverters.Converters.DTO
{
    internal class ProductModelToDtoTypeConverter : ITypeConverter<List<Tuple<ProductModel, SupplierModel>>, List<ProductDTO>>
    {
        public List<ProductDTO> Convert(List<Tuple<ProductModel, SupplierModel>> source, List<ProductDTO> destination, ResolutionContext context)
        {
            List<ProductDTO> result = new List<ProductDTO>();

            var suppliers = context.Mapper.Map<List<SupplierDTO>>(source.Select(x => x.Item2).ToList());

            foreach(var item in source)
            {
                var productModel = item.Item1;
                var currentSupplier = suppliers.FirstOrDefault(x => x.Id.Equals(item.Item1.SupplierId));
                result.Add(new ProductDTO(productModel.Id, productModel.Description, productModel.Situation.GetData(), 
                    productModel.MadeOn, productModel.ExpiresAt, currentSupplier));
            }

            return result;
        }
    }
}
