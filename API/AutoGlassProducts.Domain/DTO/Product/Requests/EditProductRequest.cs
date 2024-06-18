using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using MediatR;
using System;

namespace AutoGlassProducts.Domain.DTO.Product.Requests
{
    /// <summary>
    /// DTO de requisição de edição de produto
    /// </summary>
    /// <param name="Id">Código</param>
    /// <param name="Description">Descrição</param>
    /// <param name="MadeOn">Data de fabricação</param>
    /// <param name="ExpiresAt">Data de validade</param>
    /// <param name="SupplierId">Código do fornecedor</param>
    public record EditProductRequest(
        int Id,
        string Description,
        DateTime MadeOn,
        DateTime ExpiresAt,
        int SupplierId
        ) : IRequest<ActionResponse<ProductResponse>>
    {
    }
}
