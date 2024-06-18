using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.Validations.Product;
using System.Linq;

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
        /// <summary>
        /// Realiza validações nas propriedades
        /// </summary>
        /// <returns>Container-resposta de ações</returns>
        public ActionResponse<object> Validate()
        {
            var validator = new GetProductRequestValidator();
            var validationResponse = validator.Validate(this);
            if (validationResponse.IsValid)
                return ActionResponse<object>.Ok();

            return ActionResponse<object>.UnprocessableEntity(validationResponse.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
