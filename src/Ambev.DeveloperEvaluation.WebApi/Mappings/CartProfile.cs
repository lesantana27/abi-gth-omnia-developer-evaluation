using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            //  Commom
            CreateMap<Application.Carts.CartResult, WebApi.Features.Carts.CartResponse>();
            CreateMap<Application.Carts.CartItemResult, WebApi.Features.Carts.CartItemResponse>();


            //  Create
            CreateMap<WebApi.Features.Carts.CreateCart.CreateCartRequest, Application.Carts.CreateCart.CreateCartCommand>();
            CreateMap<WebApi.Features.Carts.CreateCart.CreateCartItemRequest, Application.Carts.CreateCart.CreateCartItemCommand>();

            //  Get
            CreateMap<WebApi.Features.Carts.GetCart.GetCartListRequest, Application.Carts.GetCart.GetCartListCommand>();
            CreateMap<Application.Carts.GetCart.GetCartListResult, WebApi.Features.Carts.GetCart.GetCartListResponse>();
            //CreateMap<Guid, Application.Carts.GetCart.GetCartByIdCommand>().ConstructUsing(id => new Application.Carts.GetCart.GetCartByIdCommand(id));
        }
    }
}
