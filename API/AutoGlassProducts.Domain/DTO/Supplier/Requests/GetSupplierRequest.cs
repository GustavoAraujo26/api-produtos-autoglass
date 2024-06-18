using ArchitectureTools.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.DTO.Supplier.Requests
{
    /// <summary>
    /// DTO de requisição de busca de fornecedor pelo código
    /// </summary>
    /// <param name="Id"></param>
    public record GetSupplierRequest(
        int Id
        ) : IRequest<ActionResponse<SupplierDTO>>
    {
    }
}
