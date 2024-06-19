using ArchitectureTools.Responses;
using Asp.Versioning;
using AutoGlassProducts.Api.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;

namespace AutoGlassProducts.Api.Controllers
{
    /// <summary>
    /// Controlador de fornecedores
    /// </summary>
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/supplier")]
    [ApiController]
    [SwaggerTag("Ações de manipulação de fornecedores")]
    public class SupplierController : BaseController
    {
        /// <summary>
        /// Cria novo fornecedor
        /// </summary>
        /// <param name="mediator">Interface do mediator</param>
        /// <param name="request">DTO de requisição de criação de fornecedor</param>
        /// <returns>Container-resposta</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<SupplierResponse>))]
        public async Task<ActionResult> Create([FromServices] IMediator mediator,
            [FromBody] CreateSupplierRequest request) =>
            BuildResponse(await mediator.Send(request));

        /// <summary>
        /// Apaga fornecedor (soft-delete)
        /// </summary>
        /// <param name="mediator">Interface do mediator</param>
        /// <param name="id">Código do fornecedor</param>
        /// <returns>Container-resposta</returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<SupplierResponse>))]
        public async Task<ActionResult> Delete([FromServices] IMediator mediator,
            [FromRoute] int id)
        {
            var request = new DeleteSupplierRequest(id);
            return BuildResponse(await mediator.Send(request));
        }

        /// <summary>
        /// Edita dados do fornecedor
        /// </summary>
        /// <param name="mediator">Interface do mediator</param>
        /// <param name="request">DTO de requisição de edição de fornecedor</param>
        /// <returns>Container-resposta</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<SupplierResponse>))]
        public async Task<ActionResult> Edit([FromServices] IMediator mediator,
            [FromBody] EditSupplierRequest request) =>
            BuildResponse(await mediator.Send(request));

        /// <summary>
        /// Habilita fornecedor
        /// </summary>
        /// <param name="mediator">Interface do mediator</param>
        /// <param name="id">Código do fornecedor</param>
        /// <returns>Container-resposta</returns>
        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<SupplierResponse>))]
        public async Task<ActionResult> Enable([FromServices] IMediator mediator,
            [FromRoute] int id)
        {
            var request = new EnableSupplierRequest(id);
            return BuildResponse(await mediator.Send(request));
        }

        /// <summary>
        /// Busca fornecedor pelo seu código
        /// </summary>
        /// <param name="mediator">Interface do mediator</param>
        /// <param name="id">Código do fornecedor</param>
        /// <returns>Container-resposta</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<SupplierResponse>))]
        public async Task<ActionResult> Get([FromServices] IMediator mediator,
            [FromRoute] int id)
        {
            var request = new GetSupplierRequest(id);
            return BuildResponse(await mediator.Send(request));
        }

        /// <summary>
        /// Retorna lista paginada de fornecedor
        /// </summary>
        /// <param name="mediator">Interface do mediator</param>
        /// <param name="request">DTO de requisição de paginação de fornecedores</param>
        /// <returns>Container-resposta</returns>
        [HttpPost]
        [Route("List")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ActionResponse<SupplierResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<SupplierResponse>))]
        public async Task<ActionResult> List([FromServices] IMediator mediator,
            [FromBody] ListSupplierRequest request) =>
            BuildResponse(await mediator.Send(request));
    }
}
