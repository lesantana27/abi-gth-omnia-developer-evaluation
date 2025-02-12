using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    class GetProductByIdValidator : AbstractValidator<GetProductByIdCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetProductByIdCommand
        /// </summary>
        public GetProductByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required");
        }
    }
}
