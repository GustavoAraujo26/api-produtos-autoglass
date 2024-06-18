namespace AutoGlassProducts.Domain.DTO.Product.Requests
{
    /// <summary>
    /// Requisição de habilitação de produto
    /// </summary>
    /// <param name="Id">Código do produto</param>
    public record EnableProductRequest(
        int Id
        )
    {
    }
}
