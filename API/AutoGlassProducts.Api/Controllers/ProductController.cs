using ArchitectureTools.Responses;
using Asp.Versioning;
using AutoGlassProducts.Api.Controllers.Base;
using AutoGlassProducts.Domain.DTO.Product;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace AutoGlassProducts.Api.Controllers
{
    /// <summary>
    /// Controlador de produtos
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/product")]
    [ApiController]
    [SwaggerTag("Ações de manipulação de produtos")]
    public class ProductController : BaseController
    {
        /// <summary>
        /// Cria novo produto
        /// </summary>
        /// <param name="mediator">Interface do mediator</param>
        /// <param name="request">DTO de requisição de criação de produto</param>
        /// <returns>Container-resposta</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<ProductResponse>))]
        public async Task<ActionResult> Create([FromServices] IMediator mediator, 
            [FromBody] CreateProductRequest request) => 
            BuildResponse(await mediator.Send(request));

        /// <summary>
        /// Apaga produto (soft-delete)
        /// </summary>
        /// <param name="mediator">Interface do mediator</param>
        /// <param name="id">Código do produto</param>
        /// <returns>Container-resposta</returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<ProductResponse>))]
        public async Task<ActionResult> Delete([FromServices] IMediator mediator,
            [FromRoute] int id)
        {
            var request = new DeleteProductRequest(id);
            return BuildResponse(await mediator.Send(request));
        }

        /// <summary>
        /// Edita dados do produto
        /// </summary>
        /// <param name="mediator">Interface do mediator</param>
        /// <param name="request">DTO de requisição de edição de produto</param>
        /// <returns>Container-resposta</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<ProductResponse>))]
        public async Task<ActionResult> Edit([FromServices] IMediator mediator,
            [FromBody] EditProductRequest request) =>
            BuildResponse(await mediator.Send(request));

        /// <summary>
        /// Habilita produto
        /// </summary>
        /// <param name="mediator">Interface do mediator</param>
        /// <param name="id">Código do produto</param>
        /// <returns>Container-resposta</returns>
        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ActionResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<ProductResponse>))]
        public async Task<ActionResult> Enable([FromServices] IMediator mediator,
            [FromRoute] int id)
        {
            var request = new EnableProductRequest(id);
            return BuildResponse(await mediator.Send(request));
        }

        /// <summary>
        /// Busca produto pelo seu código
        /// </summary>
        /// <param name="mediator">Interface do mediator</param>
        /// <param name="id">Código do produto</param>
        /// <returns>Container-resposta</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<ProductDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse<ProductDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse<ProductDTO>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ActionResponse<ProductDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<ProductDTO>))]
        public async Task<ActionResult> Get([FromServices] IMediator mediator,
            [FromRoute] int id)
        {
            var request = new GetProductRequest(id);
            return BuildResponse(await mediator.Send(request));
        }

        /// <summary>
        /// Retorna lista paginada de produtos
        /// </summary>
        /// <param name="mediator">Interface do mediator</param>
        /// <param name="request">DTO de requisição de paginação de produtos</param>
        /// <returns>Container-resposta</returns>
        [HttpPost]
        [Route("List")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse<ListProductResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse<ListProductResponse>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ActionResponse<ListProductResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ActionResponse<ListProductResponse>))]
        public async Task<ActionResult> List([FromServices] IMediator mediator,
            [FromBody] ListProductsRequest request) =>
            BuildResponse(await mediator.Send(request));
    }
}
