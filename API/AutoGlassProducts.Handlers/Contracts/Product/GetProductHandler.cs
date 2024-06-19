using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Product;
using AutoGlassProducts.Domain.DTO.Product.Requests;
using AutoGlassProducts.Domain.Handlers.Product;
using AutoGlassProducts.Domain.Repositories;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Product
{
    internal class GetProductHandler : IGetProductHandler
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ActionResponse<ProductDTO>> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return ActionResponse<ProductDTO>.BadRequest("Null request!");

            var validationResponse = request.Validate();
            if (validationResponse.IsFailure)
                return ActionResponse<ProductDTO>.Copy(validationResponse);

            var currentProduct = await _repository.Get(request.Id);
            if (currentProduct is null)
                return ActionResponse<ProductDTO>.NotFound($"Product {request.Id} not found!");

            var dto = _mapper.Map<ProductDTO>(currentProduct);

            return ActionResponse<ProductDTO>.Ok(dto);
        }
    }
}
