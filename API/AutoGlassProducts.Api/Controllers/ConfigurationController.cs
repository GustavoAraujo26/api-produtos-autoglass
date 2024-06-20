using ArchitectureTools.Responses;
using Asp.Versioning;
using AutoGlassProducts.Api.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using AutoGlassProducts.Domain.Repositories;

namespace AutoGlassProducts.Api.Controllers
{
    /// <summary>
    /// Controlador de configurações da API
    /// </summary>
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/configuration")]
    [ApiController]
    [SwaggerTag("Ações de configuração da API")]
    public class ConfigurationController : BaseController
    {
        /// <summary>
        /// Inicializa o banco de dados
        /// </summary>
        /// <param name="repository">Interface do repositório de configuração do banco de dados</param>
        /// <returns>Container-resposta</returns>
        [HttpPost]
        [Route("database/initialization")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<object>))]
        public async Task<ActionResult> InitializeDatabase([FromServices] IDatabaseConfigurationRepository repository) =>
            BuildResponse(await repository.Configure());

        /// <summary>
        /// Verifica se o banco de dados está totalmente configurado
        /// </summary>
        /// <param name="repository">Interface do repositório de configuração do banco de dados</param>
        /// <returns>Container-resposta</returns>
        [HttpGet]
        [Route("database/check")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<object>))]
        public async Task<ActionResult> CheckDatabase([FromServices] IDatabaseConfigurationRepository repository) =>
            BuildResponse(await repository.CheckConfiguration());
    }
}
