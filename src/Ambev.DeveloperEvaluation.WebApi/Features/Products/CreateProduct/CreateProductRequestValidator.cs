using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Validator for CreateUserRequest that defines validation rules for user creation.
    /// </summary>
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Title: Required, length between 3 and 50 characters
        /// </remarks>
        public CreateProductRequestValidator()
        {
            RuleFor(product => product.Title).NotEmpty().Length(3, 50);
        }
    }
}
