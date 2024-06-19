using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using MediatR;

namespace AutoGlassProducts.Domain.Handlers.Product
{
    /// <summary>
    /// Interface do manipulador de busca de produto
    /// </summary>
    public interface IGetProductHandler : IRequestHandler<GetProductRequest, ActionResponse<ProductDTO>>
    {
    }
}
