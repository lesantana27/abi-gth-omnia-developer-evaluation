using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //  Create
            CreateMap<WebApi.Features.Products.ProductRequest, Application.Products.CreateProduct.CreateProductCommand>();
            CreateMap<Application.Products.ProductResult, WebApi.Features.Products.ProductResponse>();

            //  Get
            CreateMap<Guid, Application.Products.GetProduct.GetProductByIdCommand>().ConstructUsing(id => new Application.Products.GetProduct.GetProductByIdCommand(id));

            CreateMap<WebApi.Features.Products.GetProduct.GetProductListRequest, Application.Products.GetProduct.GetProductListCommand>();

            CreateMap<Application.Products.ProductResult, WebApi.Features.Products.ProductResponse>();
            CreateMap<Application.Products.GetProduct.GetProductListResult, WebApi.Features.Products.GetProduct.GetProductListResponse>();

            //  Update
            CreateMap<WebApi.Features.Products.UpdateProduct.UpdateProductRequest, Application.Products.UpdateProduct.UpdateProductCommand>();
            CreateMap<WebApi.Features.Products.ProductRequest, WebApi.Features.Products.UpdateProduct.UpdateProductRequest>();

            //  Delete
        }
    }
}
