using ArchitectureTools.Enums;
using AutoGlassProducts.Domain.DTO.Supplier;
using System;

namespace AutoGlassProducts.Domain.DTO.Product
{
    /// <summary>
    /// DTO de produto
    /// </summary>
    /// <param name="Id">Código</param>
    /// <param name="Description">Descrição</param>
    /// <param name="Status">Status</param>
    /// <param name="MadeOn">Data de fabricação</param>
    /// <param name="ExpiresAt">Data de validade</param>
    /// <param name="Supplier">Fornecedor</param>
    public record ProductDTO(
        int Id,
        string Description,
        EnumData Status,
        DateTime MadeOn,
        DateTime ExpiresAt,
        SupplierDTO Supplier
        );
}
