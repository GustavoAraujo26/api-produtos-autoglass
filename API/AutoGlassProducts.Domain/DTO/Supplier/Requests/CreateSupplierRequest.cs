using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.DTO.Supplier.Requests
{
    /// <summary>
    /// DTO de requisição de criação de fornecedor
    /// </summary>
    /// <param name="Document">Documento (CNPJ)</param>
    /// <param name="Description">Descrição</param>
    public record CreateSupplierRequest(
        string Document,
        string Description
        ) : IRequest<ActionResponse<ProductResponse>>
    {
    }
}
