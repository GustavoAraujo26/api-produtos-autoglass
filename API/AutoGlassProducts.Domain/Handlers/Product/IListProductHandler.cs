using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.Handlers.Product
{
    /// <summary>
    /// Interface do manipulador de listagem de produtos
    /// </summary>
    public interface IListProductHandler : IRequestHandler<ListProductsRequest, ActionResponse<ListProductResponse>>
    {
    }
}
