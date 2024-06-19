using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.Handlers.Product;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Product
{
    internal class CreateProductHandler : ICreateProductHandler
    {
        public Task<ActionResponse<ProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
