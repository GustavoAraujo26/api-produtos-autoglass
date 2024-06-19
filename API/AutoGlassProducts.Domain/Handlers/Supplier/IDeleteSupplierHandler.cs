using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.Handlers.Supplier
{
    /// <summary>
    /// Interface do manipulador de deleção de fornecedores (soft-delete)
    /// </summary>
    public interface IDeleteSupplierHandler : IRequestHandler<DeleteSupplierRequest, ActionResponse<SupplierResponse>>
    {
    }
}
