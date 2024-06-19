using ArchitectureTools.Responses;
using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using AutoGlassProducts.Domain.DTO.Supplier.Responses;
using AutoGlassProducts.Domain.Handlers.Supplier;
using AutoGlassProducts.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Handlers.Contracts.Supplier
{
    internal class ListSupplierHandler : IListSupplierHandler
    {
        private readonly ISupplierRepository _repository;

        public ListSupplierHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionResponse<ListSupplierResponse>> Handle(ListSupplierRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return ActionResponse<ListSupplierResponse>.BadRequest("Null request!");

            var validationResponse = request.Validate();
            if (validationResponse.IsFailure)
                return ActionResponse<ListSupplierResponse>.Copy(validationResponse);

            var listContainer = await _repository.List(request);

            return ActionResponse<ListSupplierResponse>.Ok(listContainer);
        }
    }
}
