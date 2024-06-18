using ArchitectureTools.Pagination;
using System.Collections.Generic;

namespace AutoGlassProducts.Domain.DTO.Product.Responses
{
    /// <summary>
    /// DTO de resposta de listagem de produtos
    /// </summary>
    /// <param name="Products">Lista de produtos</param>
    /// <param name="Page">Dados de paginação</param>
    public record ListProductResponse(
        List<ProductDTO> Products,
        Page Page
        );
}
