using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.Handlers.Product;
using AutoGlassProducts.Domain.Repositories;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Product
{
    internal class CreateProductHandler : ICreateProductHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository productRepository, ISupplierRepository supplierRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<ActionResponse<ProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return ActionResponse<ProductResponse>.BadRequest("Null request");

            var validationResponse = request.Validate();
            if (validationResponse.IsFailure)
                return ActionResponse<ProductResponse>.Copy(validationResponse);

            var currentSupplier = await _supplierRepository.Get(request.SupplierId);
            if (currentSupplier is null)
                return ActionResponse<ProductResponse>.BadRequest($"Supplier {request.SupplierId} not found!");

            var product = _mapper.Map<Domain.Entities.Product>(request);
            product.AddSupplier(currentSupplier);

            var saveResult = await _productRepository.Save(product);

            return ActionResponse<ProductResponse>.Ok(saveResult);
        }
    }
}
