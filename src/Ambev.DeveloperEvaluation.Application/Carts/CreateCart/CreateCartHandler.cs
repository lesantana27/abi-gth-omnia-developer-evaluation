using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, CartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateCartHandler
        /// </summary>
        /// <param name="cartRepository">The cart repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateCartHandler(ICartRepository cartRepository, IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateCartCommand request
        /// </summary>
        /// <param name="createCartCommand">The CreateCart command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created cart details</returns>
        public async Task<CartResult> Handle(CreateCartCommand createCartCommand, CancellationToken cancellationToken)
        {
            var cart = _mapper.Map<Cart>(createCartCommand);

            var validationResult = cart.Validate();
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //var user = await _userRepository.GetByIdAsync(cart.UserId, cancellationToken);
            //if (user == null)
            //    throw new ValidationException("O usuário não existe.");

            for (int i = 0; i < cart.CartItemList.Count; i++)
            {
                var productId = cart.CartItemList[i].ProductId;
                var product = await _productRepository.GetByIdAsync(productId, cancellationToken);
                if (product == null)
                    throw new ValidationException($"O produto de código [{productId}] não existe.");

                cart.CartItemList[i].Title = product.Title;
                cart.CartItemList[i].Price = product.Price;
            }

            var createdCart = await _cartRepository.CreateAsync(cart, cancellationToken);
            var result = _mapper.Map<CartResult>(createdCart);
            return result;
        }

    }
}
