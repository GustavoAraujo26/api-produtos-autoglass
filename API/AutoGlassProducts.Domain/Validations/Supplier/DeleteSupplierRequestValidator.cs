using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using FluentValidation;

namespace AutoGlassProducts.Domain.Validations.Supplier
{
    internal class DeleteSupplierRequestValidator : AbstractValidator<DeleteSupplierRequest>
    {
        public DeleteSupplierRequestValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("{PropertyName} invalid!");
        }
    }
}
