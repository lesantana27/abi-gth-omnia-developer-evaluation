using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartItemRequestValidator : AbstractValidator<CreateCartItemRequest>
    {
        public CreateCartItemRequestValidator()
        {
            RuleFor(a => a.ProductId).NotEmpty().WithMessage("O Id do produto é obrigatório.");
            RuleFor(a => a.Quantity).InclusiveBetween(1, 20).WithMessage("A quantidade deve ser entre 1 até 20.");
        }
    }
}
