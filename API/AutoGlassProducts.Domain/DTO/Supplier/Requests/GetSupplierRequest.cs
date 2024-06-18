using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.Validations.Supplier;
using MediatR;
using System.Linq;

namespace AutoGlassProducts.Domain.DTO.Supplier.Requests
{
    /// <summary>
    /// DTO de requisição de busca de fornecedor pelo código
    /// </summary>
    /// <param name="Id"></param>
    public record GetSupplierRequest(
        int Id
        ) : IRequest<ActionResponse<SupplierDTO>>
    {
        /// <summary>
        /// Realiza validações nas propriedades
        /// </summary>
        /// <returns>Container-resposta de ações</returns>
        public ActionResponse<object> Validate()
        {
            var validator = new GetSupplierRequestValidator();
            var validationResponse = validator.Validate(this);
            if (validationResponse.IsValid)
                return ActionResponse<object>.Ok();

            return ActionResponse<object>.UnprocessableEntity(validationResponse.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
