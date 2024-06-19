using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using AutoGlassProducts.Domain.Handlers.Supplier;
using AutoGlassProducts.Domain.Repositories;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Supplier
{
    internal class CreateSupplierHandler : ICreateSupplierHandler
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;

        public CreateSupplierHandler(ISupplierRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ActionResponse<SupplierResponse>> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return ActionResponse<SupplierResponse>.BadRequest("Null request!");

            var validationResponse = request.Validate();
            if (validationResponse.IsFailure)
                return ActionResponse<SupplierResponse>.Copy(validationResponse);

            var currentSupplier = _mapper.Map<Domain.Entities.Supplier>(request);

            var saveResponse = await _repository.Save(currentSupplier);

            return ActionResponse<SupplierResponse>.Ok(saveResponse);
        }
    }
}
