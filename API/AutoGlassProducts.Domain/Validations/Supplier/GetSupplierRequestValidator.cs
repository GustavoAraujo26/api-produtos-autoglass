using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using FluentValidation;

namespace AutoGlassProducts.Domain.Validations.Supplier
{
    internal class GetSupplierRequestValidator : AbstractValidator<GetSupplierRequest>
    {
        public GetSupplierRequestValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("{PropertyName} invalid!");
        }
    }
}
