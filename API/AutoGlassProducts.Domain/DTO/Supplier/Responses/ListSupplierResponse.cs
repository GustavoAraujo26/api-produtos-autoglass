using ArchitectureTools.Pagination;
using System.Collections.Generic;

namespace AutoGlassProducts.Domain.DTO.Supplier.Responses
{
    /// <summary>
    /// DTO de resposta de listagem de fornecedores
    /// </summary>
    /// <param name="Suppliers">Lista de fornecedores</param>
    /// <param name="Page">Dados de paginação</param>
    public record ListSupplierResponse(
        List<SupplierDTO> Suppliers,
        Page Page
        );
}
