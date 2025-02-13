using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of UpdateProductHandler
        /// </summary>
        /// <param name="productRepository">The product repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the UpdateProductHandler request
        /// </summary>
        /// <param name="updateProductCommand">The Update Product command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated product details</returns>
        public async Task<ProductResult> Handle(UpdateProductCommand updateProductCommand, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(updateProductCommand);
            
            var validationResult = product.Validate();
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var updatedproduct = await _productRepository.UpdateAsync(product, cancellationToken);
            var result = _mapper.Map<ProductResult>(updatedproduct);
            return result;
        }

    }
}
