using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.DTO.Supplier.Requests
{
    /// <summary>
    /// DTO de requisição de deleção de fornecedor (soft-delete)
    /// </summary>
    /// <param name="Id">Código</param>
    public record DeleteSupplierRequest(
        int Id
        ) : IRequest<SupplierResponse>
    {
    }
}
