using AutoGlassProducts.Domain.DTO.Product.Requests;
using FluentValidation;

namespace AutoGlassProducts.Domain.Validations.Product
{
    internal class GetProductRequestValidator : AbstractValidator<GetProductRequest>
    {
        public GetProductRequestValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("{PropertyName} invalid!");
        }
    }
}
