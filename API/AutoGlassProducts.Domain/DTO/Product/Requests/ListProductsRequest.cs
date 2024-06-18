using ArchitectureTools.Pagination;
using ArchitectureTools.Period;
using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.Enums;
using MediatR;

namespace AutoGlassProducts.Domain.DTO.Product.Requests
{
    /// <summary>
    /// DTO de requisição de listagem de produtos
    /// </summary>
    /// <param name="DescriptionTrack">Trecho de descrição para pesquisa</param>
    /// <param name="ProductStatus">Status do produto</param>
    /// <param name="MadePeriod">Período de fabricação</param>
    /// <param name="ExpirationPeriod">Período de validade</param>
    /// <param name="SupplierDescriptionTrack">Trecho de descrição do fornecedor para pesquisa</param>
    /// <param name="SupplierDocumentTrack">Trecho do documento para pesquisa</param>
    /// <param name="SupplierStatus">Status do fornecedor</param>
    /// <param name="Page">Dados de paginação</param>
    public record ListProductsRequest(
        string? DescriptionTrack,
        Status? ProductStatus,
        PeriodRange? MadePeriod,
        PeriodRange? ExpirationPeriod,
        string? SupplierDescriptionTrack,
        string? SupplierDocumentTrack,
        Status? SupplierStatus,
        Page Page
        ) : IRequest<ActionResponse<ListProductResponse>>
    {
    }
}
