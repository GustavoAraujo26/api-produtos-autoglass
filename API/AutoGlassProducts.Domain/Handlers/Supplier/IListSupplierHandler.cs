using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.Handlers.Supplier
{
    /// <summary>
    /// Interface do manipulador de listagem de fornecedores
    /// </summary>
    public interface IListSupplierHandler : IRequestHandler<ListSupplierRequest, ActionResponse<ListSupplierResponse>>
    {
    }
}
