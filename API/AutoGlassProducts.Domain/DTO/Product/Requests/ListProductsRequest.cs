using ArchitectureTools.Period;
using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.Enums;
using AutoGlassProducts.Domain.Validations.Product;
using MediatR;
using System.Linq;

namespace AutoGlassProducts.Domain.DTO.Product.Requests
{
    /// <summary>
    /// DTO de requisição de listagem de produtos
    /// </summary>
    /// <param name="DescriptionTrack">Trecho de descrição para pesquisa</param>
    /// <param name="ProductSituation">Situação do produto</param>
    /// <param name="MadePeriod">Período de fabricação</param>
    /// <param name="ExpirationPeriod">Período de validade</param>
    /// <param name="SupplierDescriptionTrack">Trecho de descrição do fornecedor para pesquisa</param>
    /// <param name="SupplierDocumentTrack">Trecho do documento para pesquisa</param>
    /// <param name="SupplierSituation">Situação do fornecedor</param>
    /// <param name="Page">Página selecionada</param>
    /// <param name="PageSize">Tamanho da página</param>
    public record ListProductsRequest(
        string? DescriptionTrack,
        Situation? ProductSituation,
        PeriodRange? MadePeriod,
        PeriodRange? ExpirationPeriod,
        string? SupplierDescriptionTrack,
        string? SupplierDocumentTrack,
        Situation? SupplierSituation,
        int Page,
        int PageSize
        ) : IRequest<ActionResponse<ListProductResponse>>
    {
        /// <summary>
        /// Realiza validações nas propriedades
        /// </summary>
        /// <returns>Container-resposta de ações</returns>
        public ActionResponse<object> Validate()
        {
            var validator = new ListProductsRequestValidator();
            var validationResponse = validator.Validate(this);
            if (validationResponse.IsValid)
                return ActionResponse<object>.Ok();

            return ActionResponse<object>.UnprocessableEntity(validationResponse.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
