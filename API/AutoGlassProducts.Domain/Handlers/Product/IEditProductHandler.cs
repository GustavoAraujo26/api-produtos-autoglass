using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.Handlers.Product
{
    /// <summary>
    /// Interface do manipulador de edição de produto
    /// </summary>
    public interface IEditProductHandler : IRequestHandler<EditProductRequest, ActionResponse<ProductResponse>>
    {
    }
}
