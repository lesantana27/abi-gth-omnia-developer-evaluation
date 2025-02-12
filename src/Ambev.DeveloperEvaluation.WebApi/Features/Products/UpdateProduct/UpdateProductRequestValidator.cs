using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        /// <summary>
        /// Initializes validation rules for UpdateProductRequestValidator
        /// </summary>
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required");
        }
    }
}
