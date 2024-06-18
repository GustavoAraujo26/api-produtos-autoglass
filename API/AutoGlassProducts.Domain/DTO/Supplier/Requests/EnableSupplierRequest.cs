using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.DTO.Supplier.Requests
{
    /// <summary>
    /// Requisição de habilitação de fornecedor
    /// </summary>
    /// <param name="Id">Código</param>
    public record EnableSupplierRequest(
        int Id
        ) : IRequest<ActionResponse<SupplierResponse>>
    {
    }
}
