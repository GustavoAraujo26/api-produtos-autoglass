using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using AutoGlassProducts.Domain.Validations.Supplier;
using MediatR;
using System.Linq;

namespace AutoGlassProducts.Domain.DTO.Supplier.Requests
{
    /// <summary>
    /// Requisição de habilitação de fornecedor
    /// </summary>
    /// <param name="Id">Código</param>
    public record EnableSupplierRequest(
        int Id
        ) : IRequest<ActionResponse<SupplierResponse>>
    {
        /// <summary>
        /// Realiza validações nas propriedades
        /// </summary>
        /// <returns>Container-resposta de ações</returns>
        public ActionResponse<object> Validate()
        {
            var validator = new EnableSupplierRequestValidator();
            var validationResponse = validator.Validate(this);
            if (validationResponse.IsValid)
                return ActionResponse<object>.Ok();

            return ActionResponse<object>.UnprocessableEntity(validationResponse.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
