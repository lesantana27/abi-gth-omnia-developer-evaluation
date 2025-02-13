using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateProductHandler
        /// </summary>
        /// <param name="productRepository">The product repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateProductCommand request
        /// </summary>
        /// <param name="createProductCommand">The CreateProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product details</returns>
        public async Task<ProductResult> Handle(CreateProductCommand createProductCommand, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(createProductCommand);

            var validationResult = product.Validate();
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var createdProduct = await _productRepository.CreateAsync(product, cancellationToken);
            var result = _mapper.Map<ProductResult>(createdProduct);
            return result;
        }

    }
}
