using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.Entities;
using System.Threading.Tasks;

namespace AutoGlassProducts.Domain.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Persiste dados de produto
        /// </summary>
        /// <param name="product">Entidade produto</param>
        /// <returns>DTO de resposta de produto</returns>
        Task<ProductResponse> Save(Product product);

        /// <summary>
        /// Busca dados do produto pelo seu código
        /// </summary>
        /// <param name="id">Código</param>
        /// <returns>Entidade produto</returns>
        Task<Product> Get(int id);

        /// <summary>
        /// Obtém lista paginada de produtos, com base em parâmetros de pesquisa
        /// </summary>
        /// <param name="request">DTO de requisição de listagem de produtos</param>
        /// <returns>DTO de resposta de listagem de produtos</returns>
        Task<ListProductResponse> List(ListProductsRequest request);
    }
}
