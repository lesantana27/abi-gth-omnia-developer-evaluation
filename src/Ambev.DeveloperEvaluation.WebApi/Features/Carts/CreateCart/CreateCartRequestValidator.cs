using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
    {
        public CreateCartRequestValidator()
        {
            RuleFor(a => a.UserId).NotEmpty().WithMessage("O Id do usuário é obrigatório.");
            RuleFor(a => a.BranchName).NotEmpty().WithMessage("O nome da filial que faz a venda é obrigatório.");
            RuleFor(a => a.BranchName).Length(3, 50).WithMessage("O nome da filial tem que conter entre 3 e 50 caracteres.");

            RuleFor(a=>a.CartItemList.Count).GreaterThan(0).WithMessage("Não existe nenhum produto para criar o carrinho de compras.");

            RuleForEach(x => x.CartItemList).SetValidator(new CreateCartItemRequestValidator());
        }
    }
}
