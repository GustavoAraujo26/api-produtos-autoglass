using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.Validations.Product;
using System.Linq;

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
        /// <summary>
        /// Realiza validações nas propriedades
        /// </summary>
        /// <returns>Container-resposta de ações</returns>
        public ActionResponse<object> Validate()
        {
            var validator = new EnableProductRequestValidator();
            var validationResponse = validator.Validate(this);
            if (validationResponse.IsValid)
                return ActionResponse<object>.Ok();

            return ActionResponse<object>.UnprocessableEntity(validationResponse.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
