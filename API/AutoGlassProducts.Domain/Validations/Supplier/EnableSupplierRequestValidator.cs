using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using FluentValidation;

namespace AutoGlassProducts.Domain.Validations.Supplier
{
    internal class EnableSupplierRequestValidator : AbstractValidator<EnableSupplierRequest>
    {
        public EnableSupplierRequestValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("{PropertyName} invalid!");
        }
    }
}
