using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using AutoGlassProducts.Domain.Handlers.Supplier;
using AutoGlassProducts.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Supplier
{
    internal class DeleteSupplierHandler : IDeleteSupplierHandler
    {
        private readonly ISupplierRepository _repository;

        public DeleteSupplierHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionResponse<SupplierResponse>> Handle(DeleteSupplierRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return ActionResponse<SupplierResponse>.BadRequest("Null request!");

            var validationResponse = request.Validate();
            if (validationResponse.IsFailure)
                return ActionResponse<SupplierResponse>.Copy(validationResponse);

            var currentSupplier = await _repository.Get(request.Id);
            if (currentSupplier is null)
                return ActionResponse<SupplierResponse>.NotFound($"Supplier {request.Id} not found!");

            currentSupplier.Disable();

            var saveResult = await _repository.Save(currentSupplier);

            return ActionResponse<SupplierResponse>.Ok(saveResult);
        }
    }
}
