using AutoGlassProducts.Domain.DTO.Supplier.Requests;
using FluentValidation;

namespace AutoGlassProducts.Domain.Validations.Supplier
{
    internal class ListSupplierRequestValidator : AbstractValidator<ListSupplierRequest>
    {
        public ListSupplierRequestValidator()
        {
            RuleFor(x => x.DescriptionTrack)
                .MaximumLength(200)
                .WithMessage("{PropertyName} must have maximum {MaxLength} charecters!")
                .When(x => !string.IsNullOrEmpty(x.DescriptionTrack));

            RuleFor(x => x.DocumentTrack)
                .MaximumLength(14)
                .WithMessage("{PropertyName} must have maximum {MaxLength} charecters!")
                .When(x => !string.IsNullOrEmpty(x.DocumentTrack));

            RuleFor(x => x.Page).NotEqual(0).WithMessage("{PropertyName} invalid!");

            RuleFor(x => x.PageSize).NotEqual(0).WithMessage("{PropertyName} invalid!");
        }
    }
}
