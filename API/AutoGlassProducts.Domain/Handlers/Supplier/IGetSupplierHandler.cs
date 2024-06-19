using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using MediatR;

namespace AutoGlassProducts.Domain.Handlers.Supplier
{
    /// <summary>
    /// Interface do manipulador de busca de fornecedor
    /// </summary>
    public interface IGetSupplierHandler : IRequestHandler<GetSupplierRequest, ActionResponse<SupplierDTO>>
    {
    }
}
