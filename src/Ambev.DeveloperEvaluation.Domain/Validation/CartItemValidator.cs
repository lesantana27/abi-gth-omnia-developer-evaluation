using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class CartItemValidator : AbstractValidator<CartItem>
    {
        public CartItemValidator()
        {
            RuleFor(a => a.ProductId).NotEmpty().WithMessage("O Id do produto é obrigatório.");
            //RuleFor(a => a.Quantity).InclusiveBetween(1, 20).WithMessage("A quantidade deve ser entre 1 até 20.");
        }
    }
}
