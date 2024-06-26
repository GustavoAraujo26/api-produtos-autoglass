﻿using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using MediatR;

namespace AutoGlassProducts.Domain.Handlers.Supplier
{
    /// <summary>
    /// Interface do manipulador de criação de fornecedor
    /// </summary>
    public interface ICreateSupplierHandler : IRequestHandler<CreateSupplierRequest, ActionResponse<SupplierResponse>>
    {
    }
}
