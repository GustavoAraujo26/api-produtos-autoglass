using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using AutoGlassProducts.Domain.Enums;
using AutoGlassProducts.Domain.Validations.Supplier;
using MediatR;
using System.Linq;

namespace AutoGlassProducts.Domain.DTO.Supplier.Requests
{
    /// <summary>
    /// DTO de requisição de listagem de fornecedores
    /// </summary>
    /// <param name="DescriptionTrack">Trecho de descrição para pesquisa</param>
    /// <param name="DocumentTrack">Trecho de documento (CNPJ) para pesquisa</param>
    /// <param name="Situation">Situação</param>
    /// <param name="Page">Página atual</param>
    /// <param name="PageSize">Tamanho da página</param>
    public record ListSupplierRequest(
        string? DescriptionTrack,
        string? DocumentTrack,
        Situation? Situation,
        int Page,
        int PageSize
        ) : IRequest<ActionResponse<ListSupplierResponse>>
    {
        /// <summary>
        /// Realiza validações nas propriedades
        /// </summary>
        /// <returns>Container-resposta de ações</returns>
        public ActionResponse<object> Validate()
        {
            var validator = new ListSupplierRequestValidator();
            var validationResponse = validator.Validate(this);
            if (validationResponse.IsValid)
                return ActionResponse<object>.Ok();

            return ActionResponse<object>.UnprocessableEntity(validationResponse.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
