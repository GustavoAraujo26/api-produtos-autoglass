using ArchitectureTools.Pagination;
using AutoGlassProducts.Domain.Enums;

namespace AutoGlassProducts.Domain.DTO.Supplier.Requests
{
    /// <summary>
    /// DTO de requisição de listagem de fornecedores
    /// </summary>
    /// <param name="DescriptionTrack">Trecho de descrição para pesquisa</param>
    /// <param name="DocumentTrack">Trecho de documento (CNPJ) para pesquisa</param>
    /// <param name="Status">Status</param>
    /// <param name="Page">Dados de paginação</param>
    public record ListSupplierRequest(
        string? DescriptionTrack,
        string? DocumentTrack,
        Status? Status,
        Page Page
        )
    {
    }
}
