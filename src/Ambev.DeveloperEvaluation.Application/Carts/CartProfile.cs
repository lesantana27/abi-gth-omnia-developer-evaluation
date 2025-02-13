using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Domain.Entities.Cart, Application.Carts.CartResult>();
            CreateMap<Domain.Entities.CartItem, Application.Carts.CartItemResult>();

            CreateMap<Application.Carts.CreateCart.CreateCartCommand, Domain.Entities.Cart>();
            CreateMap<Application.Carts.CreateCart.CreateCartItemCommand, Domain.Entities.CartItem>();


            //CreateMap<Application.Carts.UpdateCart.UpdateCartCommand, Domain.Entities.Cart>();
        }
    }
}
