using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            //  Create
            CreateMap<WebApi.Features.Carts.CreateCart.CreateCartRequest, Application.Carts.CreateCart.CreateCartCommand>();
            CreateMap<WebApi.Features.Carts.CreateCart.CreateCartItemRequest, Application.Carts.CreateCart.CreateCartItemCommand>();
            CreateMap<Application.Carts.CartResult, WebApi.Features.Carts.CartResponse>();
            CreateMap<Application.Carts.CartItemResult, WebApi.Features.Carts.CartItemResponse>();
        }
    }
}
