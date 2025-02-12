using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductListHandler : IRequestHandler<GetProductListCommand, GetProductListResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetProductListHandler
        /// </summary>
        /// <param name="productRepository">The product repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetProductListHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetProductListCommand request
        /// </summary>
        /// <param name="request">The GetProductList command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product details if found</returns>
        public async Task<GetProductListResult> Handle(GetProductListCommand request, CancellationToken cancellationToken)
        {
            //var validator = new GetProductListValidator();
            //var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //if (!validationResult.IsValid)
            //    throw new ValidationException(validationResult.Errors);

            var productList = await _productRepository.GetAllAsync(cancellationToken);
            if (productList == null)
                throw new KeyNotFoundException($"Products not found");

            var getProductListResult = new GetProductListResult();
            getProductListResult.ProductList = _mapper.Map<List<ProductResult>>(productList);

            return getProductListResult;
        }
    }
}
