namespace AutoGlassProducts.Domain.DTO.Product.Responses
{
    /// <summary>
    /// DTO de resposta de produto salvo
    /// </summary>
    /// <param name="Id">Código</param>
    /// <param name="Description">Descrição</param>
    public record ProductResponse(
        int Id,
        string Description
        );
}
