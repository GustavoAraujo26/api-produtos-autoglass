using AutoGlassProducts.Domain.DTO.Product.Requests;
using FluentValidation;

namespace AutoGlassProducts.Domain.Validations.Product
{
    internal class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductRequestValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("{PropertyName} invalid!");
        }
    }
}
