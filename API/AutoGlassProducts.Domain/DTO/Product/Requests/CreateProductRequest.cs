using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using MediatR;
using System;

namespace AutoGlassProducts.Domain.DTO.Product.Requests
{
    /// <summary>
    /// DTO de requisição de criação de produto
    /// </summary>
    /// <param name="Description">Descrição</param>
    /// <param name="MadeOn">Data de fabricação</param>
    /// <param name="ExpiresAt">Data de validade</param>
    /// <param name="SupplierId">Código do fornecedor</param>
    public record CreateProductRequest(
        string Description,
        DateTime MadeOn,
        DateTime ExpiresAt,
        int SupplierId
        ) : IRequest<ActionResponse<ProductResponse>>
    {

    }
}
