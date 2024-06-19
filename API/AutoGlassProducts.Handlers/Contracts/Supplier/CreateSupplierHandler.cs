using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.Handlers.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Supplier
{
    internal class CreateSupplierHandler : ICreateSupplierHandler
    {
        public Task<ActionResponse<ProductResponse>> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
