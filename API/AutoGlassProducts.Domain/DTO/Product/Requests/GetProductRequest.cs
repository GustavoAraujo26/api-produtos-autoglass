namespace AutoGlassProducts.Domain.DTO.Product.Requests
{
    /// <summary>
    /// DTO de requisição de busca de produto por código
    /// </summary>
    /// <param name="Id">Código</param>
    public record GetProductRequest(
        int Id
        )
    {
    }
}
