using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.Handlers.Product;
using AutoGlassProducts.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Product
{
    internal class EnableProductHandler : IEnableProductHandler
    {
        private readonly IProductRepository _repository;

        public EnableProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionResponse<ProductResponse>> Handle(EnableProductRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return ActionResponse<ProductResponse>.BadRequest("Null request!");

            var validationResponse = request.Validate();
            if (validationResponse.IsFailure)
                return ActionResponse<ProductResponse>.Copy(validationResponse);

            var currentProduct = await _repository.Get(request.Id);
            if (currentProduct is null)
                return ActionResponse<ProductResponse>.NotFound($"Product {request.Id} not found!");

            currentProduct.Enable();

            var saveResponse = await _repository.Save(currentProduct);

            return ActionResponse<ProductResponse>.Ok(saveResponse);
        }
    }
}
