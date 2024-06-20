using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.Handlers.Supplier;
using AutoGlassProducts.Domain.Repositories;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Supplier
{
    internal class GetSupplierHandler : IGetSupplierHandler
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;

        public GetSupplierHandler(ISupplierRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ActionResponse<SupplierDTO>> Handle(GetSupplierRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return ActionResponse<SupplierDTO>.BadRequest("Null request!");

            var validationResponse = request.Validate();
            if (validationResponse.IsFailure)
                return ActionResponse<SupplierDTO>.Copy(validationResponse);

            var currentSupplier = await _repository.Get(request.Id);
            if (currentSupplier is null)
                return ActionResponse<SupplierDTO>.NotFound($"Supplier {request.Id} not found!");

            var dto = _mapper.Map<SupplierDTO>(currentSupplier);

            return ActionResponse<SupplierDTO>.Ok(dto);
        }
    }
}
