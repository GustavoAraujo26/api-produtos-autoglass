namespace AutoGlassProducts.Domain.DTO.Supplier.Responses
{
    /// <summary>
    /// DTO de resposta de fornecedor salvo
    /// </summary>
    /// <param name="Id">Código</param>
    /// <param name="Description">Descrição</param>
    public record SupplierResponse(
        int Id,
        string Description
        );
}
