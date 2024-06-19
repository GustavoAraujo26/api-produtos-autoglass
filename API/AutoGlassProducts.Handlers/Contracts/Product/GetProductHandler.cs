using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.Handlers.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Product
{
    internal class GetProductHandler : IGetProductHandler
    {
        public Task<ActionResponse<ProductDTO>> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
