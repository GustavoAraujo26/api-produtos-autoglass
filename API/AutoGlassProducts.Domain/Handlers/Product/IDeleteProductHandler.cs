using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.Handlers.Product
{
    /// <summary>
    /// Interface do manipulador de deleção de produto (soft-delete)
    /// </summary>
    public interface IDeleteProductHandler : IRequestHandler<DeleteProductRequest, ActionResponse<ProductResponse>>
    {
    }
}
