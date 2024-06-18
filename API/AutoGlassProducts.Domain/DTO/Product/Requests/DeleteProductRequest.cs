using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.Validations.Product;
using MediatR;
using System.Linq;

namespace AutoGlassProducts.Domain.DTO.Product.Requests
{
    /// <summary>
    /// DTO de deleção de produto (soft-delete)
    /// </summary>
    /// <param name="Id">Código do produto</param>
    public record DeleteProductRequest(
        int Id
        ) : IRequest<ActionResponse<ProductResponse>>
    {
        /// <summary>
        /// Realiza validações nas propriedades
        /// </summary>
        /// <returns>Container-resposta de ações</returns>
        public ActionResponse<object> Validate()
        {
            var validator = new DeleteProductRequestValidator();
            var validationResponse = validator.Validate(this);
            if (validationResponse.IsValid)
                return ActionResponse<object>.Ok();

            return ActionResponse<object>.UnprocessableEntity(validationResponse.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
