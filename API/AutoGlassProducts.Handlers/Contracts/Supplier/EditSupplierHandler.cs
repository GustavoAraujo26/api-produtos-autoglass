using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using AutoGlassProducts.Domain.Handlers.Supplier;
using AutoGlassProducts.Domain.Repositories;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Supplier
{
    internal class EditSupplierHandler : IEditSupplierHandler
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;

        public EditSupplierHandler(ISupplierRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ActionResponse<SupplierResponse>> Handle(EditSupplierRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return ActionResponse<SupplierResponse>.BadRequest("Null request!");

            var validationResponse = request.Validate();
            if (validationResponse.IsFailure)
                return ActionResponse<SupplierResponse>.Copy(validationResponse);

            var currentSupplier = await _repository.Get(request.Id);
            if (currentSupplier is null)
                return ActionResponse<SupplierResponse>.NotFound($"Supplier {request.Id} not found!");

            var updateContainer = new Tuple<EditSupplierRequest, Domain.Entities.Supplier>(request, currentSupplier);
            var updatedSupplier = _mapper.Map<Domain.Entities.Supplier>(updateContainer);

            var saveResponse = await _repository.Save(updatedSupplier);

            return ActionResponse<SupplierResponse>.Ok(saveResponse);
        }
    }
}
