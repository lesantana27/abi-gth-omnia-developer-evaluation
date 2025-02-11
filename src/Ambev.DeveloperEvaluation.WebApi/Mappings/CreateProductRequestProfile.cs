using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class CreateProductRequestProfile : Profile
    {
        public CreateProductRequestProfile()
        {
            CreateMap<WebApi.Features.Products.CreateProduct.CreateProductRequest, Application.Products.CreateProduct.CreateProductCommand>();
            CreateMap<WebApi.Features.Products.CreateProduct.CreateProductResponse, Application.Products.CreateProduct.CreateProductResult>();
            CreateMap<Application.Products.CreateProduct.CreateProductResult, WebApi.Features.Products.CreateProduct.CreateProductResponse>();
        }
    }
}
