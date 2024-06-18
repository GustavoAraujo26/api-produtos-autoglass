using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.DTO.Product.Requests
{
    /// <summary>
    /// DTO de deleção de produto (soft-delete)
    /// </summary>
    /// <param name="Id">Código do produto</param>
    public record DeleteProductRequest(
        int Id
        ) : IRequest<ActionResponse<ProductResponse>>
    {
    }
}
