using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Title)
                .NotEmpty()
                .MinimumLength(3).WithMessage("O título do produto tem que ter no mínimo 3 caracteres.")
                .MaximumLength(50).WithMessage("O título do produto tem que ter no máximo 50 caracteres.");

            RuleFor(product => product.Price)
                .GreaterThan(0).WithMessage("O preço do produto tem que ser maior que zero.");

            RuleFor(product => product.RatingCount)
                .GreaterThanOrEqualTo(0).WithMessage("O contador da avaliação tem que ser zero ou maior.");

            RuleFor(product => product.RatingRate)
                .GreaterThanOrEqualTo(0).WithMessage("A pontuação da avaliação tem que ser zero ou maior.");
        }
    }
}
