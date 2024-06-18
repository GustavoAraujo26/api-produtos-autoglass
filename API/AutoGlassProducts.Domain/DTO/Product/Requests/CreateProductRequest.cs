using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.Validations.Product;
using MediatR;
using System;
using System.Linq;

namespace AutoGlassProducts.Domain.DTO.Product.Requests
{
    /// <summary>
    /// DTO de requisição de criação de produto
    /// </summary>
    /// <param name="Description">Descrição</param>
    /// <param name="MadeOn">Data de fabricação</param>
    /// <param name="ExpiresAt">Data de validade</param>
    /// <param name="SupplierId">Código do fornecedor</param>
    public record CreateProductRequest(
        string Description,
        DateTime MadeOn,
        DateTime ExpiresAt,
        int SupplierId
        ) : IRequest<ActionResponse<ProductResponse>>
    {
        /// <summary>
        /// Realiza validações nas propriedades
        /// </summary>
        /// <returns>Container-resposta de ações</returns>
        public ActionResponse<object> Validate()
        {
            var validator = new CreateProductRequestValidator();
            var validationResponse = validator.Validate(this);
            if (validationResponse.IsValid)
                return ActionResponse<object>.Ok();

            return ActionResponse<object>.UnprocessableEntity(validationResponse.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
