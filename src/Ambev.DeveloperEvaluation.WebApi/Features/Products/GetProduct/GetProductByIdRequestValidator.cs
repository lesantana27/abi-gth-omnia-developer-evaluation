using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{
    /// <summary>
    /// Validator for GetProductByIdRequest
    /// </summary>
    public class GetProductByIdRequestValidator : AbstractValidator<GetProductByIdRequest>
    {
        /// <summary>
        /// Initializes validation rules for GetProductByIdRequest
        /// </summary>
        public GetProductByIdRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required");
        }
    }
}
