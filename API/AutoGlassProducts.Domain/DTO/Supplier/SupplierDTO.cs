using ArchitectureTools.Enums;

namespace AutoGlassProducts.Domain.DTO.Supplier
{
    /// <summary>
    /// DTO de fornecedor
    /// </summary>
    /// <param name="Id">Código</param>
    /// <param name="Document">Documento (CNPJ)</param>
    /// <param name="Description">Descrição</param>
    /// <param name="Status">Status</param>
    public record SupplierDTO(
        int Id,
        string Document,
        string Description,
        EnumData Status
        );
}
