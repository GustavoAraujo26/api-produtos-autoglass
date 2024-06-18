using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using FluentValidation;

namespace AutoGlassProducts.Domain.Validations.Supplier
{
    internal class EditSupplierRequestValidator : AbstractValidator<EditSupplierRequest>
    {
        public EditSupplierRequestValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("{PropertyName} invalid!");

            RuleFor(x => x.Description)
                .MaximumLength(200)
                .WithMessage("{PropertyName} must have maximum {MaxLength} charecters!");

            RuleFor(x => x.Document)
                .MaximumLength(14)
                .WithMessage("{PropertyName} must have maximum {MaxLength} charecters!");
        }
    }
}
