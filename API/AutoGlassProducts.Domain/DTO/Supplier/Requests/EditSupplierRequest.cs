using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.DTO.Supplier.Requests
{
    /// <summary>
    /// DTO de requisição de edição de fornecedor
    /// </summary>
    /// <param name="Id">Código</param>
    /// <param name="Document">Documento (CNPJ)</param>
    /// <param name="Description">Descrição</param>
    public record EditSupplierRequest(
        int Id,
        string Document,
        string Description
        ) : IRequest<ActionResponse<SupplierResponse>>
    {
    }
}
