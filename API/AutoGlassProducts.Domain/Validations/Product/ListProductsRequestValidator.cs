using AutoGlassProducts.Domain.DTO.Product.Requests;
using FluentValidation;

namespace AutoGlassProducts.Domain.Validations.Product
{
    internal class ListProductsRequestValidator : AbstractValidator<ListProductsRequest>
    {
        public ListProductsRequestValidator()
        {
            RuleFor(x => x.DescriptionTrack)
                .MaximumLength(200)
                .WithMessage("{PropertyName} must have maximum {MaxLength} charecters!")
                .When(x => !string.IsNullOrEmpty(x.DescriptionTrack));

            RuleFor(x => x.SupplierDescriptionTrack)
                .MaximumLength(200)
                .WithMessage("{PropertyName} must have maximum {MaxLength} charecters!")
                .When(x => !string.IsNullOrEmpty(x.SupplierDescriptionTrack));

            RuleFor(x => x.SupplierDocumentTrack)
                .MaximumLength(14)
                .WithMessage("{PropertyName} must have maximum {MaxLength} charecters!")
                .When(x => !string.IsNullOrEmpty(x.SupplierDocumentTrack));

            RuleFor(x => x.Page).NotEqual(0).WithMessage("{PropertyName} invalid!");

            RuleFor(x => x.PageSize).NotEqual(0).WithMessage("{PropertyName} invalid!");

            RuleFor(x => x.MadePeriod).Custom((obj, context) =>
            {
                if (obj == null)
                    return;

                var validationResult = obj.Value.Validate();
                if (validationResult.IsFailure)
                    context.AddFailure(validationResult.Message);
            });

            RuleFor(x => x.ExpirationPeriod).Custom((obj, context) =>
            {
                if (obj == null)
                    return;

                var validationResult = obj.Value.Validate();
                if (validationResult.IsFailure)
                    context.AddFailure(validationResult.Message);
            });
        }
    }
}
