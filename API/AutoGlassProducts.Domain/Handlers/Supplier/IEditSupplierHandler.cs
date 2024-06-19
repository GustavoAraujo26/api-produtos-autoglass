using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.Handlers.Supplier
{
    /// <summary>
    /// Interface do manipulador de edição de fornecedor
    /// </summary>
    public interface IEditSupplierHandler : IRequestHandler<EditSupplierRequest, ActionResponse<SupplierResponse>>
    {
    }
}
