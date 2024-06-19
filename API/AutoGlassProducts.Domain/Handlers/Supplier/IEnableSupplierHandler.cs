using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.Handlers.Supplier
{
    /// <summary>
    /// Interface do manipulador de habilitação de fornecedor
    /// </summary>
    public interface IEnableSupplierHandler : IRequestHandler<EnableSupplierRequest, ActionResponse<SupplierResponse>>
    {
    }
}
