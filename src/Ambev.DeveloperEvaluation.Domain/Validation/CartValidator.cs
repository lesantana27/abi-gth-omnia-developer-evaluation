using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class CartValidator : AbstractValidator<Cart>
    {
        public CartValidator()
        {
            //RuleFor(a => a.).GreaterThan(0).WithMessage("O preço do produto tem que ser maior que zero.");
        }
    }
}
