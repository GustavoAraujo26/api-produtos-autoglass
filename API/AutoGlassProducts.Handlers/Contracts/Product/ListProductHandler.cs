using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.Handlers.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Product
{
    internal class ListProductHandler : IListProductHandler
    {
        public Task<ActionResponse<ListProductResponse>> Handle(ListProductsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
