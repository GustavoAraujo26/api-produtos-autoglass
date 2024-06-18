using AutoGlassProducts.Domain.DTO.Product.Requests;
using FluentValidation;
using System;

namespace AutoGlassProducts.Domain.Validations.Product
{
    internal class EditProductRequestValidator : AbstractValidator<EditProductRequest>
    {
        public EditProductRequestValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("{PropertyName} invalid!");

            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .NotNull().NotEmpty().WithMessage("{PropertyName} invalid!")
                .MaximumLength(200).WithMessage("{PropertyName} must have maximum {MaxLength} charecters!");

            RuleFor(x => x.MadeOn)
                .Cascade(CascadeMode.Stop)
                .NotEqual(DateTime.MinValue).WithMessage("{PropertyName} invalid!")
                .LessThan(x => x.ExpiresAt).WithMessage("{PropertyName} must be less than {ComparisonProperty}");

            RuleFor(x => x.ExpiresAt).NotEqual(DateTime.MinValue).WithMessage("{PropertyName} invalid!");

            RuleFor(x => x.SupplierId).NotEqual(0).WithMessage("{PropertyName} invalid!");
        }
    }
}
