using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using AutoGlassProducts.Domain.Handlers.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Supplier
{
    internal class ListSupplierHandler : IListSupplierHandler
    {
        public Task<ActionResponse<ListSupplierResponse>> Handle(ListSupplierRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
