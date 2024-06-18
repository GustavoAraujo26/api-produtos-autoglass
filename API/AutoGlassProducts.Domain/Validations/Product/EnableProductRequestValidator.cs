using AutoGlassProducts.Domain.DTO.Product.Requests;
using FluentValidation;

namespace AutoGlassProducts.Domain.Validations.Product
{
    internal class EnableProductRequestValidator : AbstractValidator<EnableProductRequest>
    {
        public EnableProductRequestValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("{PropertyName} invalid!");
        }
    }
}
