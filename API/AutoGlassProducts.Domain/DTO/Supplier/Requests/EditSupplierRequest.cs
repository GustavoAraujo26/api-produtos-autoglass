﻿using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using AutoGlassProducts.Domain.Validations.Supplier;
using MediatR;
using System.Linq;

namespace AutoGlassProducts.Domain.DTO.Supplier.Requests
{
    /// <summary>
    /// DTO de requisição de edição de fornecedor
    /// </summary>
    /// <param name="Id">Código</param>
    /// <param name="Document">Documento (CNPJ)</param>
    /// <param name="Description">Descrição</param>
    public record EditSupplierRequest(
        int Id,
        string Document,
        string Description
        ) : IRequest<ActionResponse<SupplierResponse>>
    {
        /// <summary>
        /// Realiza validações nas propriedades
        /// </summary>
        /// <returns>Container-resposta de ações</returns>
        public ActionResponse<object> Validate()
        {
            var validator = new EditSupplierRequestValidator();
            var validationResponse = validator.Validate(this);
            if (validationResponse.IsValid)
                return ActionResponse<object>.Ok();

            return ActionResponse<object>.UnprocessableEntity(validationResponse.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
