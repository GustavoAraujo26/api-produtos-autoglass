using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.DTO.Product.Responses;
using AutoGlassProducts.Domain.Handlers.Product;
using AutoGlassProducts.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Product
{
    internal class ListProductHandler : IListProductHandler
    {
        private readonly IProductRepository _repository;

        public ListProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionResponse<ListProductResponse>> Handle(ListProductsRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return ActionResponse<ListProductResponse>.BadRequest("Null request!");

            var validationResponse = request.Validate();
            if (validationResponse.IsFailure)
                return ActionResponse<ListProductResponse>.Copy(validationResponse);

            var listContainer = await _repository.List(request);

            return ActionResponse<ListProductResponse>.Ok(listContainer);
        }
    }
}
