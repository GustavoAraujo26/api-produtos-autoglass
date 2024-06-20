using ArchitectureTools.Responses;
using System.Threading.Tasks;

namespace AutoGlassProducts.Domain.Repositories
{
    /// <summary>
    /// Interface do repositório de configuração do banco de dados
    /// </summary>
    public interface IDatabaseConfigurationRepository
    {
        /// <summary>
        /// Configura a estrutura do banco de dados
        /// </summary>
        /// <returns>Container-resposta</returns>
        Task<ActionResponse<object>> Configure();

        /// <summary>
        /// Verifica se o banco está totalmente configurado
        /// </summary>
        /// <returns>Container-resposta</returns>
        Task<ActionResponse<object>> CheckConfiguration();
    }
}
