using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Specifications;
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

        public CreateCartHandler(ICartRepository cartRepository, IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CartResult> Handle(CreateCartCommand createCartCommand, CancellationToken cancellationToken)
        {
            var cart = _mapper.Map<Cart>(createCartCommand);

            var validationResult = cart.Validate();
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            foreach (var cartItem in cart.CartItemList)
            {
                var product = await _productRepository.GetByIdAsync(cartItem.ProductId, cancellationToken);
                if (product == null)
                    throw new KeyNotFoundException($"O produto de código [{cartItem.ProductId}] não existe.");

                var cartItemQuantityLimitSpecification = new CartItemQuantityLimitSpecification();
                if (!cartItemQuantityLimitSpecification.IsSatisfiedBy(cartItem))
                {
                    throw new Exception("A quantidade do produto deve ser entre 1 até 20.");
                }

                cartItem.Title = product.Title;
                cartItem.Price = product.Price;
            }

            var createdCart = await _cartRepository.CreateAsync(cart, cancellationToken);
            var result = _mapper.Map<CartResult>(createdCart);
            return result;
        }

    }
}
