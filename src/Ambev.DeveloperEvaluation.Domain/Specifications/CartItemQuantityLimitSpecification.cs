using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Specifications
{
    public class CartItemQuantityLimitSpecification : ISpecification<CartItem>
    {
        public bool IsSatisfiedBy(CartItem cartItem)
        {
            return cartItem.Quantity < 21;
        }
    }
}
