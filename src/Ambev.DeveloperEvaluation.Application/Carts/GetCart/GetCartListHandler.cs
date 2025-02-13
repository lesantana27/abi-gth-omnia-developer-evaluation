using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart
{
    public class GetCartListHandler : IRequestHandler<GetCartListCommand, GetCartListResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartListHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<GetCartListResult> Handle(GetCartListCommand request, CancellationToken cancellationToken)
        {
            var cartList = await _cartRepository.GetAllAsync(cancellationToken);

            var getCartListResult = new GetCartListResult();
            getCartListResult.CartList = _mapper.Map<List<CartResult>>(cartList);

            return getCartListResult;
        }
    }
}
