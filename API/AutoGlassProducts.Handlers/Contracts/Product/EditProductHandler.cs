using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.Enums;
using AutoGlassProducts.Domain.Handlers.Product;
using AutoGlassProducts.Domain.Repositories;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Product
{
    internal class EditProductHandler : IEditProductHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public EditProductHandler(IProductRepository productRepository, ISupplierRepository supplierRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<ActionResponse<ProductResponse>> Handle(EditProductRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return ActionResponse<ProductResponse>.BadRequest("Null request!");

            var validationResponse = request.Validate();
            if (validationResponse.IsFailure)
                return ActionResponse<ProductResponse>.Copy(validationResponse);

            var currentProduct = await _productRepository.Get(request.Id);
            if (currentProduct is null)
                return ActionResponse<ProductResponse>.NotFound($"Product {request.Id} not found!");

            var updateContainer = new Tuple<EditProductRequest, Domain.Entities.Product>(request, currentProduct);
            var updatedProduct = _mapper.Map<Domain.Entities.Product>(updateContainer);

            var selectedSupplier = await _supplierRepository.Get(request.SupplierId);
            if (selectedSupplier is null)
                return ActionResponse<ProductResponse>.NotFound($"Supplier {request.SupplierId} not found!");

            if (currentProduct.Supplier.Id != request.SupplierId)
            {
                if (selectedSupplier.Situation == Situation.Disabled)
                    return ActionResponse<ProductResponse>.BadRequest("Cannot associate product to disabled supplier!");

                updatedProduct.AddSupplier(selectedSupplier);
            }

            var saveResult = await _productRepository.Save(updatedProduct);

            return ActionResponse<ProductResponse>.Ok(saveResult);
        }
    }
}
